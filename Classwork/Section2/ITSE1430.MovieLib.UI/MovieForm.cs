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

        public Movie Movie { get; set; }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            //_btnSave.Click += _btnSave_Click;
            if (Movie != null)
            {
                _textName.Text = Movie.Name;
                _textDescription.Text = Movie.Description;
                _textRelease.Text = Movie.ReleaseYear.ToString();
                _textRunLang.Text = Movie.RunLength.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };
            ValidateChildren();
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Event Handlers

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;


            var movie = new Movie();

            //Name is required
            movie.Name = _textName.Text;
            movie.Description = _textDescription.Text;
            movie.ReleaseYear = GetInt32(_textRelease);
            movie.RunLength = GetInt32(_textRunLang);
            movie.IsOwned = _chkOwned.Checked;

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();

            //Using properties so don't need the method calls
            //movie.SetName(_txtName.Text);
            //movie.SetDescription(_txtDescription.Text);
            //movie.SetReleaseYear(GetInt32(_txtReleaseYear));
            //if (movie.GetReleaseYear() < 0)
            //movie.SetRunLength(GetInt32(_txtRunLength));
            //if (movie.GetRunLength() < 0)
        }

        #endregion

        #region Private Members

        private int GetInt32(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }
        #endregion

        private void OnValidateName(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void OnValidatingReleaseYear(object sender,  System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1900)
            {
                _error.SetError(control, "Must be > 1900");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }
        private void OnValidatingRunLength(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0)
            {
                _errors.SetError(control, "Must be > 0");
                e.Cancel = true;
            }
            _errors.SetError(control, "");
        }

      
    }
}