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
    public partial class MainForm : Form
    {
        private ContactsList contactsList;
        private IMessagingService messagingService;

        /// <summary>
        /// Initialize the user interface
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            contactsList = new ContactsList();
            messagingService = new DummyMessagingService(messagesListView);
        }

        /// <summary>
        /// Show the about window
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Show the window for creating a new contact
        /// </summary>
        private void newContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactForm form = new ContactForm();

            while (true)
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                try
                {
                    // Attempt to add
                    contactsList.AddContact(form.Contact);

                    // Dislay all contacts
                    RefreshContactsList();
                    return;
                }
                catch(Exception ex)
                {
                    // If there's an error, then re-do
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
        }

        /// <summary>
        /// Display the contacts list
        /// </summary>
        private void RefreshContactsList()
        {
            contactsListBox.Items.Clear();

            foreach (IContact contact in contactsList.Contacts)
                contactsListBox.Items.Add(contact.Name);
        }

        /// <summary>
        /// Send an email to the selected contact
        /// </summary>
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = contactsListBox.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Select first a contact from the list.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = contactsListBox.SelectedItem.ToString();
            PersonContact contact = (PersonContact) contactsList.FindContact(name);

            EmailForm form = new EmailForm(contact);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            messagingService.Send(contact.EmailAddress, form.Subject, form.Message);
        }

        /// <summary>
        /// Edit a contact
        /// </summary>
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = contactsListBox.SelectedIndex;

            if (index == -1)
                return;

            string oldName = contactsListBox.SelectedItem.ToString();
            IContact contact = contactsList.FindContact(oldName);

            ContactForm form = new ContactForm(contact);

            while (true)
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;

                try
                {
                    // Attempt to update
                    contactsList.UpdateContact(oldName, form.Contact);

                    // Dislay all contacts
                    RefreshContactsList();
                    return;
                }
                catch (Exception ex)
                {
                    // If there's an error, then re-do
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// When double clicked, edit the selected contact
        /// </summary>
        private void contactsListBox_DoubleClick(object sender, EventArgs e)
        {
            editContactToolStripMenuItem.PerformClick();
        }

        /// <summary>
        /// Delete the selected contact
        /// </summary>
        private void deleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(contactsListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a contact to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm for deletion
            string name = contactsListBox.SelectedItem.ToString();

            if (MessageBox.Show("Are you sure you want to delete '" + name + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                contactsList.RemoveContact(name);
                RefreshContactsList();
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
    }
}
