using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSE1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        public Movie Movie;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave(object sender, EventArgs e)
        {
            var movie = new Movie();
            var movie2 = new Movie();
            var name = movie2.GetName();

            //Name is reguired
            movie.SetName (_textName.Text);
            if (String.IsNullOrEmpty(_textName.Text))
                return;

            //Realese year is numeric, if set
             movie.SetReleaseYear (GetInt32(_textRelease));
            if (movie.GetReleaseYear() < 0)
                return;

            //  movie.setRunLength = _textDescription.Text;
            //Run Lenght, if set
            movie.SetRunLength(GetInt32(_textRunLang));
            if (movie.GetRunLength() < 0)
                return;

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }
        private int GetInt32 (TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}
    }

    

}
