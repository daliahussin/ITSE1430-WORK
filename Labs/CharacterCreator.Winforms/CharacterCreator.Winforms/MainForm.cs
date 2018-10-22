using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class MainForm : Form
    {
        private int numCharacters;
        private Character[] characters;

        /// <summary>
        /// Initialize the UI
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            numCharacters = 0;
            characters = new Character[100];
        }

        /// <summary>
        /// Close the window and terminate the application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        /// <summary>
        /// Show the about form
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Show window for creating a new character
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check for space available
            if(numCharacters >= characters.Length)
            {
                MessageBox.Show("Character list is full.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show window to create character
            CharacterForm form = new CharacterForm();

            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            // Add character to the list
            Character character = form.ProcessedCharacter;
            characters[numCharacters++] = character;
            charactersListBox.Items.Add(character);
        }

        /// <summary>
        /// Show window for updating an existing character
        /// </summary>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(charactersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a character in the list to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show window to update character
            CharacterForm form = new CharacterForm(characters[charactersListBox.SelectedIndex]);

            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            // Update the list
            charactersListBox.Items[charactersListBox.SelectedIndex] = form.ProcessedCharacter;
        }

        /// <summary>
        /// Allow deleting a character
        /// </summary>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (charactersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a character in the list to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm for delete
            Character character = characters[charactersListBox.SelectedIndex];

            if (MessageBox.Show("Are you sure you want to delete '" + character.Name + "'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Delete the character, replace it with the last one in the list
            if(numCharacters > 1)
            {
                characters[charactersListBox.SelectedIndex] = characters[numCharacters - 1];
                charactersListBox.Items[charactersListBox.SelectedIndex] = characters[charactersListBox.SelectedIndex];
                charactersListBox.Items.RemoveAt(numCharacters - 1);
                numCharacters--;
            }
            else
            {
                numCharacters = 0;
                charactersListBox.Items.Clear();
            }
        }
    }
}
