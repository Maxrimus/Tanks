/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for the Gamepiece objects
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Milestone_4
{
    public class GamePiece
    {
        /*Attributes and Properties
         * prectangle = the rectangle object that represents the location and dimensions of the piece
         * box - the component that will be displayed on the game screen
         */
        internal Rectangle prectangle;

        public Rectangle Prectangle
        {
            get { return prectangle; }
            set { prectangle = value; }
        }

        private PictureBox box;

        public PictureBox Box
        {
            get { return box; }
            set { box = value; }
        }

        /// <summary>
        /// Parameterized Constructor. 
        /// All parameters are passed in.
        /// </summary>
        /// <param name="x">The x position the piece starts at</param>
        /// <param name="y">The y position the piece starts at</param>
        public GamePiece(int x, int y, string filename)
        {
            //Creates the Picturebox and sets the location, among other properties
            box = new PictureBox();
            box.Location = new Point(x,y);
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.BorderStyle = BorderStyle.FixedSingle;

            //attempts to access and set the Image to the Picturebox
            try
            {
                box.Image = new Bitmap(filename);
            }
            catch(ArgumentException ae)
            {
                MessageBox.Show("Image not found.");
            }

            //sets the dimensions and location of the rectangle
            prectangle = new Rectangle(x, y, box.Width, box.Height);
        }

        /// <summary>
        /// Sets the position of the cursor
        /// </summary>
        virtual public void Draw()
        {
            box.Location = prectangle.Location;
        }

        /// <summary>
        /// The overriden ToString method
        /// </summary>
        /// <returns>Returns the location and dimensions of the piece</returns>
        public override string ToString()
        {
            return "This game piece has a Location of " + prectangle.Location + " a width of " + prectangle.Width + " and a height of " + prectangle.Height +  ".";
        }

        /// <summary>
        /// Determines if two gamepieces are colliding
        /// </summary>
        /// <param name="gp2">The second gamepiece to be compared to</param>
        /// <returns>Returns a bool of whether or not they are colliding</returns>
        public bool IsColliding(GamePiece gp2)
        {
            if (prectangle.IntersectsWith(gp2.Prectangle))
            {//uses the rectangles IntersectsWith method to determine collisions
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
