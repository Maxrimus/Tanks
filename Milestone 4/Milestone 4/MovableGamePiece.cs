/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for all GamePiece objects that move
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_4
{
    public abstract class MovableGamePiece:GamePiece
    {
        /*Attributes and Properties
         * direction - The direction the piece is facing
         */

        private int direction;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// Parameterized Constructor.
        /// All values are passed in.
        /// x and y are passed up to the base.
        /// dir is set to direction
        /// </summary>
        /// <param name="x">The x position the piece starts at</param>
        /// <param name="y">The y position the piece starts at</param>
        /// <param name="dir">The direction the piece starts facing</param>
        public MovableGamePiece(int x, int y, int dir, string filename)
            : base(x, y,filename)
        {
            direction = dir;
        }

        /// <summary>
        /// An abstract method that will be defined later.
        /// Moves the piece on screen
        /// </summary>
        abstract public void Move();

        /// <summary>
        /// Draw method
        /// Calls base draw method
        /// </summary>
        public override void Draw()
        {
            base.Draw();
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Returns base ToString and the direction it's facing</returns>
        public override string ToString()
        {
            return base.ToString() + " This is a movable piece with a direction of " + direction + ".";
        }
    }
}
