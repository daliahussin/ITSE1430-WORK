using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initialize the about form
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
