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
    public partial class EmailForm : Form
    {
        /// <summary>
        /// Initialize the window for sending email
        /// </summary>
        public EmailForm(IContact contact)
        {
            InitializeComponent();

            toTextBox.Text = contact.Name;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Access the subject
        /// </summary>
        public string Subject
        {
            get
            {
                return subjectTextBox.Text;
            }
        }

        /// <summary>
        /// Access the message
        /// </summary>
        public string Message
        {
            get
            {
                return messageTextBox.Text;
            }
        }

        /// <summary>
        /// Close the window
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Validate the message to be sent
        /// </summary>
        private void sendButton_Click(object sender, EventArgs e)
        {
            string to = toTextBox.Text.Trim();
            string subject = subjectTextBox.Text.Trim();
            string message = messageTextBox.Text.Trim();

            if(message == string.Empty)
            {
                MessageBox.Show("A message is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
