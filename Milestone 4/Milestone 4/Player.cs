/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class for the Player objects
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_4
{
    public class Player
    {
        /* Attributes and Properties
         * name - the player's name
         * number - the player's number
         * tanksLeft - the number of tanks a player has left
         */

        private string name;

        public string Name
        {
            get { return name; }
        }

        private int number;

        public int Number
        {
            get { return number; }
        }

        private int tanksLeft;

        public int TanksLeft
        {
            get { return tanksLeft; }
            set { tanksLeft = value; }
        }

        /// <summary>
        /// Parameterized Constructor.
        /// All values are passed in.
        /// </summary>
        /// <param name="nm">The name of the player</param>
        /// <param name="numb">The number of the player</param>
        /// <param name="tnks">The number of tanks the player starts with</param>
        public Player(string nm, int numb, int tnks)
        {
            name = nm;
            number = numb;
            tanksLeft = tnks;
        }

        /// <summary>
        /// Determines if the player has lost
        /// </summary>
        /// <returns>returns a bool value based on if the player has lost all of their tanks</returns>
        public bool hasLost()
        {
            //determines if player is dead by number of tanks
            if (tanksLeft <= 0)
            {//less than or equal to 0 tanks, returns true
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Takes away 1 tank from the player's remaining tanks
        /// </summary>
        public void loseTank()
        {
            tanksLeft--;
        }

        /// <summary>
        /// Overriden ToString()
        /// </summary>
        /// <returns>Gives player's name, number, and remaining tanks</returns>
        public override string ToString()
        {
            return name + " is player number " + number + " and has " + tanksLeft + " tanks left.";
        }
    }
}
