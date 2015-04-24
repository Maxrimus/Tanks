/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: A class to hold various constants and variables multiple classes will need
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_4
{
    public static class GameVariables
    {
        //Console Dimensions and Game Dimensions
        public static int GameWidth = 800;
        public static int GameHeight = 600;
        public static int InnerWidth = 800;
        public static int InnerHeight = 600;

        //Tank and Bullet speeds
        public static int TankSpeed = 4;
        public static int BulletSpeed = 10;

        //Image Files
        public static string WallImage = "wall.png";
        public static string BulletImage = "bullet.png";
        public static string GreenTankUpImage = "greentank0.png";
        public static string GreenTankRightImage = "greentank1.png";
        public static string GreenTankDownImage = "greentank2.png";
        public static string GreenTankLeftImage = "greentank3.png";
        public static string RedTankUpImage = "redtank0.png";
        public static string RedTankRightImage = "redtank1.png";
        public static string RedTankDownImage = "redtank2.png";
        public static string RedTankLeftImage = "redtank3.png";
    }
}
