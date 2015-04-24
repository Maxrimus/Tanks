/*Joseph Tursi
 * Date: 2/14/2014
 * Purpose: The starting point of the application. Runs the InfoForm
 * Exceptions:
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InfoForm());
        }
    }
}
