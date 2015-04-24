/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for the Tank objects
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Milestone_4
{
    public class Tank:MovableGamePiece
    {
        /* Attributes and Properties
         * health - Current health of the tank
         * player - Player controlling this tank
         * bullet - The bullet that the tank will fire
         * tanks - An array of images for this tank
         * startLoc - the starting location of this tank
         */

        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        private Player player;

        public Player Player
        {
            get { return player; }
        }

        private Bullet bullet;

        public Bullet Bullet
        {
            get { return bullet; }
        }

        private Bitmap[] tanks;

        public Bitmap[] Tanks
        {
            get { return tanks; }
        }

        private Point startLoc;

        public Point StartLoc
        {
            get { return startLoc; }
            set { startLoc = value; }
        }

        /// <summary>
        /// Parameterized Constructor.
        /// All values are passed in.
        /// x,y,and dir are passed up.
        /// The rest are assigned to their attribtues
        /// </summary>
        /// <param name="x">The x position the piece starts at</param>
        /// <param name="y">The y position the piece starts at</param>
        /// <param name="dir">The direction the piece starts facing</param>
        /// <param name="hlth">The beginning health of the tank</param>
        /// <param name="plyr">The player that is using this tank</param>
        /// <param name="bllt">The bullet this tank fires</param>
        public Tank(int x, int y, int dir, int hlth, Player plyr, Bullet bllt)
            : base(x, y, dir,GameVariables.GreenTankUpImage)
        {
            health = hlth;
            player = plyr;
            bullet = bllt;
            tanks = new Bitmap[4];
            if (player.Number == 2)
            {
                tanks[0] = new Bitmap(GameVariables.GreenTankUpImage);
                tanks[1] = new Bitmap(GameVariables.GreenTankRightImage);
                tanks[2] = new Bitmap(GameVariables.GreenTankDownImage);
                tanks[3] = new Bitmap(GameVariables.GreenTankLeftImage);
            }

            if (player.Number == 1)
            {
                tanks[0] = new Bitmap(GameVariables.RedTankUpImage);
                tanks[1] = new Bitmap(GameVariables.RedTankRightImage);
                tanks[2] = new Bitmap(GameVariables.RedTankDownImage);
                tanks[3] = new Bitmap(GameVariables.RedTankLeftImage);
            }
        }

        /// <summary>
        /// Moves the Tank.
        /// </summary>
        public override void Move()
        {
            //switch statement to determine which direction the tank is facing
            //Changes the coordinate accordingly
            switch (Direction)
            {
                case 0://moves the bullet up\
                    prectangle.Location = new Point(Prectangle.Location.X, Prectangle.Location.Y - GameVariables.TankSpeed);
                    break;
                case 1://moves the bullet right
                    prectangle.Location = new Point(Prectangle.Location.X + GameVariables.TankSpeed, Prectangle.Location.Y);
                    break;
                case 2://moves the bullet down
                    prectangle.Location = new Point(Prectangle.Location.X, Prectangle.Location.Y + GameVariables.TankSpeed);
                    break;
                case 3://moves the bullet left
                    prectangle.Location = new Point(Prectangle.Location.X - GameVariables.TankSpeed, Prectangle.Location.Y);
                    break;
                default:
                    break;
            }

            //series of ifs determining if the bullet is off the screen
            //if it is, sets active status to false
            if (prectangle.Location.X <= 0)
            {//top of screen
                prectangle.Location = new Point(6,prectangle.Location.Y);
            }

            if ((prectangle.Location.X + prectangle.Width + 1) >= GameVariables.InnerWidth)
            {//bottom of screen
                prectangle.Location = new Point(GameVariables.InnerWidth - (prectangle.Width), prectangle.Location.Y);
            }

            if (prectangle.Location.Y <= 0)
            {//left of screen
                prectangle.Location = new Point(prectangle.Location.X,6);
            }

            if ((prectangle.Location.Y + prectangle.Height + 1) >= GameVariables.InnerHeight)
            {//right of screen
                prectangle.Location = new Point(prectangle.Location.X, GameVariables.InnerHeight - (prectangle.Height + 1));
            }
        }

        /// <summary>
        /// Moves the Tank backwards.
        /// </summary>
        public void Reverse()
        {
            //switch statement to determine which direction the tank is facing
            //Changes the coordinate accordingly
            switch (Direction)
            {
                case 0://moves the bullet up\
                    prectangle.Location = new Point(Prectangle.Location.X, Prectangle.Location.Y + GameVariables.TankSpeed);
                    break;
                case 1://moves the bullet right
                    prectangle.Location = new Point(Prectangle.Location.X - GameVariables.TankSpeed, Prectangle.Location.Y);
                    break;
                case 2://moves the bullet down
                    prectangle.Location = new Point(Prectangle.Location.X, Prectangle.Location.Y - GameVariables.TankSpeed);
                    break;
                case 3://moves the bullet left
                    prectangle.Location = new Point(Prectangle.Location.X + GameVariables.TankSpeed, Prectangle.Location.Y);
                    break;
                default:
                    break;
            }

            //series of ifs determining if the bullet is off the screen
            //if it is, sets active status to false
            if (prectangle.Location.X == 0)
            {//top of screen
                prectangle.Location = new Point(0, prectangle.Location.Y);
            }

            if ((prectangle.Location.X + prectangle.Width) == GameVariables.InnerWidth)
            {//bottom of screen
                prectangle.Location = new Point(GameVariables.InnerWidth - prectangle.Width, prectangle.Location.Y);
            }

            if (prectangle.Location.Y == 0)
            {//left of screen
                prectangle.Location = new Point(prectangle.Location.X, 0);
            }

            if ((prectangle.Location.Y + prectangle.Height) == GameVariables.InnerHeight)
            {//right of screen
                prectangle.Location = new Point(prectangle.Location.X, GameVariables.InnerHeight - prectangle.Height);
            }
        }

        /// <summary>
        /// Method stub for Draw method.
        /// Draws the tank on screen.
        /// </summary>
        public override void Draw()
        {
            //calls the base draw 
            base.Draw();

            //determines the direction to draw the tank in
            switch (Direction)
            {
                case 0://Draws tank up
                    Box.Image = tanks[0];
                    break;
                case 1://Draws tank right
                    Box.Image = tanks[1];
                    break;
                case 2://Draws tank down
                    Box.Image = tanks[2];
                    break;
                case 3://Draws tank left
                    Box.Image = tanks[3];
                    break;
                default://Draws tank right as default
                    Box.Image = tanks[1];
                    break;
            }
        }

        /// <summary>
        /// Called when the tank is hit.
        /// Decrements the health by 1
        /// </summary>
        public void TakeHit()
        {
            //decrements health
            health--;
            //checks if tank is dead
            if (IsDead())
            {//if tank dead, resets health and takes away a player's tank
                health = 2;
                prectangle.Location = startLoc;
                player.loseTank();
            }
        }

        /// <summary>
        /// Called to check if the tank is dead.
        /// </summary>
        /// <returns>Returns false if the tank has 0 or less health</returns>
        public bool IsDead()
        {
            //determines if the tank is dead
            if (health <= 0)
            {//if health is less than or equal to 0, the tank is dead
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Fires a bullet if one is not already on screen
        /// </summary>
        public void Fire()
        {
            //if statement determines if bullet is inactive
            //if it is inactive, fires a bullet
            if (!bullet.Active)
            {
                //sets bullet position and direction to those of the tank
                bullet.prectangle.Location = new Point(prectangle.Location.X + (prectangle.Width/2),prectangle.Location.Y + (prectangle.Height/2));
                bullet.Direction = Direction;

                //draws the bullet and sets it to active
                bullet.Draw();
                bullet.Active = true;
            }
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Returns base ToString as well as the tank's health and the name of the player controlling it</returns>
        public override string ToString()
        {
            return "Tank: Health: " + health + " Location: " + prectangle.Location + " Direction: " + Direction;
        }
    }
}
