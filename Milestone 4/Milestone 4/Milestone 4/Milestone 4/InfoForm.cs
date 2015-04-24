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
    public partial class InfoForm : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method called when the Play button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Checks if there's a name for Player 1
            if (textBox1.Text == "")
            {
                MessageBox.Show("No name entered for Player 1.");
                return;
            }

            //Checks if there's a name for Player 2
            if (textBox2.Text == "")
            {
                MessageBox.Show("No name entered for Player 2.");
                return;
            }

            //Checks if there is any text for the Map File
            if (textBox3.Text == "")
            {
                MessageBox.Show("No Map File given.");
                return;
            }

            //attempts to read in the map file, to check if the map file is valid
            StreamReader map = null;
            try
            {
                map = new StreamReader(textBox3.Text);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("Invalid Map File.");
                return;
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show("Invalid Map File.");
                return;
            }
            finally
            {//closes the file
                if (map != null)
                {
                    map.Close();
                }
            }

            //Instantiates the Gameform and Shows it, hiding the InfoForm
            GameForm gf = new GameForm(this, textBox2.Text, textBox1.Text, textBox3.Text);
            gf.Show();
            this.Hide();
        }

        /// <summary>
        /// Called when the Clear button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Clears all textboxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
