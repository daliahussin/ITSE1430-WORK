﻿using ITSE1430.MovieLib;
using ITSE1430.MovieLib.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itse1430.MovieLib.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?",
                        "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {
            //aboutToolStripMenuItem.
            MessageBox.Show(this, "Sorry", "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void OnMovieAdd(object sender, EventArgs e)
        {
            var form = new MovieForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            // MessageBox.Show("Adding movie");
             Movie = form.Movie;
           // Movie.Name = "";
        }

        private Movie Movie;

      
    }
}

