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
    public partial class CharacterForm : Form
    {
        private Character character;

        /// <summary>
        /// Initialize the UI for creating character
        /// </summary>
        public CharacterForm()
        {
            InitializeComponent();

            professionComboBox.SelectedIndex = 0;
            raceComboBox.SelectedIndex = 0;

            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Initialize the UI for updating character
        /// </summary>
        public CharacterForm(Character character)
        {
            InitializeComponent();

            this.character = character;
            nameTextBox.Text = character.Name;
            professionComboBox.SelectedItem = character.Profession;
            raceComboBox.SelectedItem = character.Race;
            strengthNumericUpDown.Value = character.Strength;
            intelligenceNumericUpDown.Value = character.Intelligence;
            agilityNumericUpDown.Value = character.Agility;
            constitutionNumericUpDown.Value = character.Constitution;
            charismaNumericUpDown.Value = character.Charisma;
            descriptionTextBox.Text = character.Description;

            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Access to the created or updated character
        /// </summary>
        public Character ProcessedCharacter
        {
            get
            {
                return character;
            }
        }

        /// <summary>
        /// Create the character, validate required fields
        /// </summary>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Clear any previous errors
            errorProvider.Clear();

            // Validate the name
            string name = nameTextBox.Text.Trim();
    
            if(string.IsNullOrEmpty(name))
            {
                errorProvider.SetError(nameTextBox, "Name is required.");
                return;
            }

            // Others are UI validated so we retrieve their values
            string profession = professionComboBox.SelectedItem.ToString();
            string race = raceComboBox.SelectedItem.ToString();
            int strength = (int)strengthNumericUpDown.Value;
            int intelligence = (int)intelligenceNumericUpDown.Value;
            int agility = (int)agilityNumericUpDown.Value;
            int constitution = (int)constitutionNumericUpDown.Value;
            int charisma = (int)charismaNumericUpDown.Value;
            string description = descriptionTextBox.Text;

            if (character == null)
            {
                // Create the character and close
                character = new Character(name, profession, race, strength, intelligence, agility, constitution, charisma);
                character.Description = description;
            }
            else
            {
                // Update the character and close
                character.Name = name;
                character.Profession = profession;
                character.Race = race;
                character.Strength = strength;
                character.Intelligence = intelligence;
                character.Agility = agility;
                character.Constitution = constitution;
                character.Charisma = charisma;
                character.Description = description;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
