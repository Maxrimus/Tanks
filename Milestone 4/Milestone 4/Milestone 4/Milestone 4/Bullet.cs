/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for the Bullet objects
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
    public class Bullet:MovableGamePiece
    {
        /* Attributes and Properties
         * active - whether the bullet is on screen or not
         */
        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
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
        /// <param name="act">Whether the bullet is on screen or not</param>
        public Bullet(int x, int y, int dir, bool act)
            : base(x, y, dir,GameVariables.BulletImage)
        {
            active = act;
        }

        /// <summary>
        /// Method stub for Move method.
        /// Moves the Tank.
        /// </summary>
        public override void Move()
        {
            //if statement to determine if the bullet is active
            if (active)
            {
                //switch statement to determine which direction the tank is facing
                //Changes the coordinate accordingly
                switch (Direction)
                {
                    case 0://moves the bullet up\
                        prectangle.Location = new Point(Prectangle.Location.X,Prectangle.Location.Y - GameVariables.BulletSpeed);
                        break;
                    case 1://moves the bullet right
                        prectangle.Location = new Point(Prectangle.Location.X + GameVariables.BulletSpeed, Prectangle.Location.Y);
                        break;
                    case 2://moves the bullet down
                        prectangle.Location = new Point(Prectangle.Location.X, Prectangle.Location.Y + GameVariables.BulletSpeed);
                        break;
                    case 3://moves the bullet left
                        prectangle.Location = new Point(Prectangle.Location.X - GameVariables.BulletSpeed, Prectangle.Location.Y);
                        break;
                    default:
                        break;
                }

                //series of ifs determining if the bullet is off the screen
                //if it is, sets active status to false
                if (prectangle.Location.X <= 0)
                {//top of screen
                    active = false;
                }

                if ((prectangle.Location.X + prectangle.Width) >= GameVariables.InnerWidth)
                {//bottom of screen
                    active = false;
                }

                if (prectangle.Location.Y <= 0)
                {//left of screen
                    active = false;
                }

                if ((prectangle.Location.Y + prectangle.Height) >= GameVariables.InnerHeight)
                {//right of screen
                    active = false;
                }
            }
        }

        /// <summary>
        /// Method stub for Draw method.
        /// Draws the tank on screen.
        /// </summary>
        public override void Draw()
        {
            //determines if bullet is active
            if (active)
            {//draws bullet if active
                base.Draw();
                this.Box.Visible = true;
            }
            else
            {
                this.Box.Visible = false;
            }
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Returns base ToString as well as the bullet's state</returns>
        public override string ToString()
        {
            return "Bullet: Active: " + active + " Location: " + prectangle.Location + " Direction: " + Direction;
        }
    }
}
