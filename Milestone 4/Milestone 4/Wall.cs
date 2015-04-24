/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for the Wall objects
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_4
{
    public class Wall:GamePiece
    {
        /// <summary>
        /// Parameterized constructor. 
        /// All parameters are passed in, then passed up to the base.
        /// </summary>
        /// <param name="x">The x position the piece starts at</param>
        /// <param name="y">The y position the piece starts at</param>
        public Wall(int x, int y)
            : base(x, y,GameVariables.WallImage)
        {
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Returns base ToString and the fact that it's a wall</returns>
        public override string ToString()
        {
            return "Wall: Location: " + prectangle.Location;
        }
    }
}
