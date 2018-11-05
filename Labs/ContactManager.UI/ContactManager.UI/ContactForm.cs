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
    public partial class ContactForm : Form
    {
        private IContact contact;

        /// <summary>
        /// Initialize the window for adding a contact
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Initialize window for updating a contact
        /// </summary>
        /// <param name="contact"></param>
        public ContactForm(IContact contact)
        {
            InitializeComponent();
            this.contact = contact;

            Text = "Update Contact";
            PersonContact personContact = (PersonContact)contact;
            nameTextBox.Text = personContact.Name;
            emailAddressTextBox.Text = personContact.EmailAddress;
        }
        
        /// <summary>
        /// Access to the created contact
        /// </summary>
        public IContact Contact
        {
            get
            {
                return contact;
            }
        }

        /// <summary>
        /// Validate and create the new contact
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string emailAddress = emailAddressTextBox.Text.Trim();

            // Validate required fields
            if(name == string.Empty || emailAddress == string.Empty)
            {
                MessageBox.Show("A name and email address is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!IsValidEmail(emailAddress))
            {
                MessageBox.Show("The email address is not valid in format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the contact
            contact = new PersonContact(name, emailAddress);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Utility function for checking email address is valid
        /// </summary>
        private bool IsValidEmail(string source)
        {
            try
            {
                new System.Net.Mail.MailAddress(source);
                return true;
            }
            catch
            { };

            return false;
        }
    }
}
