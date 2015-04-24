/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: The main Game Form, holds all assets and the game loop
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Milestone_4
{
    public partial class GameForm : Form
    {
        /*Attributes and Properties
         * player1 - The first player
         * player2 - The second player
         * tank1 - The first tank
         * tank2 - The second tank
         * bullet1 - The first tank's bullet
         * bullet2 - The second tank's bullet
         * walls - The list of the walls in the field
         * gameOver - wether or not the game has ended
         * infoForm - The infoForm that will be displayed
         * player1Name - Player 1's name
         * player2Name - Player 2's Name
         * mapFile - the map file to be used
         */

        private Player player1;

        public Player Player1
        {
            get { return player1; }
        }

        private Player player2;

        public Player Player2
        {
            get { return player2; }
        }

        private Tank tank1;

        public Tank Tank1
        {
            get { return tank1; }
        }

        private Tank tank2;

        public Tank Tank2
        {
            get { return tank2; }
        }

        private Bullet bullet1;

        public Bullet Bullet1
        {
            get { return bullet1; }
        }

        private Bullet bullet2;

        public Bullet Bullet2
        {
            get { return bullet2; }
        }

        private List<Wall> walls;

        public List<Wall> Walls
        {
            get { return walls; }
        }

        private bool gameOver;

        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        private InfoForm infoForm;
        private string player1Name;
        private string player2Name;
        private string mapFile;

        /// <summary>
        /// Constructor
        /// Most values are instantiated within
        /// Some values are passed in
        /// </summary>
        /// <param name="inFrm">The infoForm to be shown</param>
        /// <param name="pl1Nm">Player 1's Name</param>
        /// <param name="pl2Nm">Player 2's Name</param>
        /// <param name="mpFl">The file where the map is stored</param>
        public GameForm(InfoForm inFrm, string pl1Nm, string pl2Nm, string mpFl)
        {
            InitializeComponent();
            
            //Puts the parameters in their variables
            infoForm = inFrm;
            player1Name = pl1Nm;
            player2Name = pl2Nm;
            mapFile = mpFl;

            //creates the objects needed
            player1 = new Player(pl1Nm, 1, 5);
            player2 = new Player(pl2Nm, 2, 5);
            bullet1 = new Bullet(0, 0, 0, false);
            bullet2 = new Bullet(0, 0, 0, false);
            tank1 = new Tank(25, 25, 0, 2, player1, bullet1);
            tank2 = new Tank(502, 502, 0, 2, player2, bullet2);
            walls = new List<Wall>();

            //Reads the map and Draws the game once
            ReadMap(mpFl);
            DrawGame();

            //Sets game over to false
            gameOver = false;

            //Sets Size of game window and full window
            this.Size = new Size(GameVariables.GameWidth, GameVariables.GameHeight);
            GameVariables.InnerWidth = this.ClientSize.Width;
            GameVariables.InnerHeight = this.ClientSize.Height;

            //Adds all the Pictureboxes to the Components lists
            Controls.Add(this.tank1.Box);
            Controls.Add(this.tank2.Box);
            Controls.Add(this.bullet1.Box);
            Controls.Add(this.bullet2.Box);
            foreach (Wall i in walls)
            {
                Controls.Add(i.Box);
            }

            //Starts the timer
            timer1.Start();
        }

        /// <summary>
        /// Ends the game.
        /// Clears the screen and prints a game over message
        /// </summary>
        /// <param name="loseCon">Determines how the game was lost. l for player win, q for quit early</param>
        public void EndGame(char loseCon)
        {
            //determines the winner and prints it out
            if (loseCon == 'l')
            {//If a player loses
                if (player1.hasLost())
                {
                    MessageBox.Show("Winner: " + player2.Name);
                }
                if (player2.hasLost())
                {
                    MessageBox.Show("Winner: " + player1.Name);
                }
            }

            if (loseCon == 'q')
            {//If the game is quit prematurely
                MessageBox.Show("Game was ended early");
            }

            //Calls the close method
            this.Close();
        }

        /// <summary>
        /// Draws the game pieces.
        /// Calls the draw methods of all objects on screen
        /// </summary>
        public void DrawGame()
        {
            //calls all pieces draw methods
            tank1.Draw();
            tank2.Draw();
            bullet1.Draw();
            bullet2.Draw();
            foreach (Wall i in walls)
            {
                i.Draw();
            }

            //Sets the text of the form to the Player names and Tanks Left
            this.Text = player1.Name + ": Tanks Left: " + player1.TanksLeft + " Health: " + tank1.Health + "//" + player2.Name + ": Tanks Left: " + player2.TanksLeft + " Health: " + tank2.Health;
        }

        /// <summary>
        /// Detects if any objects are colliding
        /// </summary>
        private void DetectCollisions()
        {
            //Checks if the first tank was hit by the second tank's bullet
            //They need to be colliding and the bullet needs to be active for the tank to be damaged
            if (tank1.IsColliding(bullet2) && bullet2.Active == true)
            {
                bullet2.Active = false;
                tank1.TakeHit();
            }

            //Checks if the second tank was hit by the first tank's bullet
            //They need to be colliding and the bullet needs to be active for the tank to be damaged
            if (tank2.IsColliding(bullet1) && bullet1.Active == true)
            {
                bullet1.Active = false;
                tank2.TakeHit();
            }

            //Cycles through the list of walls
            foreach (Wall i in walls)
            {
                //moves the first tank backwards if it is colliding with a wall
                if (tank1.IsColliding(i))
                {
                    tank1.Reverse();
                }

                //moves the second tank backwards if it is colliding with a wall
                if (tank2.IsColliding(i))
                {
                    tank2.Reverse();
                }

                //deactivates the first bullet if it is colliding with a wall
                if (bullet1.IsColliding(i))
                {
                    bullet1.Active = false;
                }

                //deactivates the second bullet if it is colliding with a wall
                if (bullet2.IsColliding(i))
                {
                    bullet2.Active = false;
                }
            }
        }

        /// <summary>
        /// Assigns tank values from txt file
        /// </summary>
        /// <param name="info">The info from the txt file</param>
        /// <param name="tank">The tank to be set</param>
        private void SetupTank(string info, Tank tank)
        {
            //the individual data points
            string[] data = info.Split(',');

            //the data in int form
            List<int> dataNum = new List<int>();

            //moves out of the method if there isn't the right amount of data
            if (!(data.Length == 3))
            {
                return;
            }

            //turns each string into an int
            foreach (string i in data)
            {
                try
                {
                    dataNum.Add(int.Parse(i));
                }
                catch (FormatException fe)
                {
                    dataNum.Add(0);
                }
            }

            //setting tank data
            tank.prectangle.Location = tank.StartLoc = new Point(dataNum[1],dataNum[0]);
            tank.Direction = dataNum[2];
        }

        /// <summary>
        /// Assigns wall values from a txt file
        /// </summary>
        /// <param name="info">The info from the txt file</param>
        private void CreateWall(string info)
        {
            //the individual data points
            string[] data = info.Split(',');

            //the data in int form
            List<int> dataNum = new List<int>();

            //moves out of the method if there isn't the right amount of data
            if (!(data.Length == 2))
            {
                return;
            }

            //turns each string into an int
            foreach (string i in data)
            {
                try
                {
                    dataNum.Add(int.Parse(i));
                }
                catch (FormatException fe)
                {
                    dataNum.Add(0);
                }
            }

            //adds the wall to the walls List
            walls.Add(new Wall(dataNum[1], dataNum[0]));
        }

        /// <summary>
        /// Reads the map text and defines data
        /// </summary>
        private void ReadMap(string mapFile)
        {
            //Creates the reader using the Map.txt file
            StreamReader reader = null;
            try
            {
                //reads in the map file
                reader = new StreamReader(mapFile);

                //reads the tank1 data
                string tank1Dat = reader.ReadLine();
                SetupTank(tank1Dat, tank1);

                //reads the tank2 data
                string tank2Dat = reader.ReadLine();
                SetupTank(tank2Dat, tank2);

                /*
                //reads the window data and sets the window size
                string windowData = reader.ReadLine();
                SetDimensions(windowData);
                */

                //loops through the rest of the data to build walls
                while (true)
                {
                    string wallData = reader.ReadLine();
                    if (wallData == null)
                    {//used to determine when the file ends
                        break;
                    }
                    //adds the wall from the data
                    CreateWall(wallData);
                }
            }
            catch (IOException ioe)
            {
                //adds a wall in about the middle of the screen, then returns
                walls.Add(new Wall(20, 12));
                return;
            }
            catch (UnauthorizedAccessException uae)
            {
                //adds a wall in about the middle of the screen, then returns
                walls.Add(new Wall(20, 12));
                return;
            }
            catch (NullReferenceException nre)
            {
                //adds a wall in about the middle of the screen, then returns
                walls.Add(new Wall(20, 12));
                return;
            }
            finally
            {
                //closes the file
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Plays the game
        /// </summary>
        public void GameLoop()
        {
            //Processes inputs, moving all pieces
            bullet1.Move();
            bullet2.Move();
            DetectCollisions();

            //Redraws the game pieces
            DrawGame();

            //breaks out of the loop if either player loses
            if (player1.hasLost())
            {
                timer1.Stop();
                EndGame('l');
            }

            if (player2.hasLost())
            {
                timer1.Stop();
                EndGame('l');
            }
        }

        /// <summary>
        /// The timer object's tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //calls the gameloop every time the Timer ticks
            GameLoop();
        }

        /// <summary>
        /// Method called when the GameForm is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Shows the infoForm when this form is closed
            this.infoForm.Show();
        }

        /// <summary>
        /// Method called when any key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch case to determine what the input effects
            switch (e.KeyChar)
            {
                case 'q'://Quits the game
                    EndGame('q');
                    gameOver = true;
                    break;
                case 'w'://sets tank 1 to move up
                    tank1.Direction = 0;
                    tank1.Move();
                    break;
                case 'a'://sets tank 1 to move left
                    tank1.Direction = 3;
                    tank1.Move();
                    break;
                case 's'://sets tank 1 to move down
                    tank1.Direction = 2;
                    tank1.Move();
                    break;
                case 'd'://sets tank 1 to move right
                    tank1.Direction = 1;
                    tank1.Move();
                    break;
                case 'f'://fires tank 1's bullet
                    tank1.Fire();
                    break;
                case 'i'://sets tank 2 to move up
                    tank2.Direction = 0;
                    tank2.Move();
                    break;
                case 'j'://sets tank 2 to move left
                    tank2.Direction = 3;
                    tank2.Move();
                    break;
                case 'k'://sets tank 2 to move down
                    tank2.Direction = 2;
                    tank2.Move();
                    break;
                case 'l'://sets tank 2 to move right
                    tank2.Direction = 1;
                    tank2.Move();
                    break;
                case 'h'://fires tank 2's bullet
                    tank2.Fire();
                    break;
            }
            //Detects any collisions after moving
            DetectCollisions();
        }
    }
}
