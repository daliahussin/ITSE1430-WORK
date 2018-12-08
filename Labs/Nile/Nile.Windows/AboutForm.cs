using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initialize the form
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// CLose the form
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
