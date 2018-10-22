/* ITSE1430
 * DALIA HUSSIN
 * 10/22/2018
 */
namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.professionLabel = new System.Windows.Forms.Label();
            this.professionComboBox = new System.Windows.Forms.ComboBox();
            this.raceComboBox = new System.Windows.Forms.ComboBox();
            this.raceLabel = new System.Windows.Forms.Label();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.strengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intelligenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intelligenceLabel = new System.Windows.Forms.Label();
            this.agilityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.agilityLabel = new System.Windows.Forms.Label();
            this.constitutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.constitutionLabel = new System.Windows.Forms.Label();
            this.charismaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.charismaLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.strengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelligenceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agilityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constitutionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charismaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(65, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(54, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(125, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(158, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // professionLabel
            // 
            this.professionLabel.AutoSize = true;
            this.professionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.professionLabel.Location = new System.Drawing.Point(29, 56);
            this.professionLabel.Name = "professionLabel";
            this.professionLabel.Size = new System.Drawing.Size(90, 17);
            this.professionLabel.TabIndex = 2;
            this.professionLabel.Text = "Profession:";
            // 
            // professionComboBox
            // 
            this.professionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.professionComboBox.FormattingEnabled = true;
            this.professionComboBox.Items.AddRange(new object[] {
            "Fighter",
            "Hunter",
            "Priest",
            "Rogue",
            "Wizard"});
            this.professionComboBox.Location = new System.Drawing.Point(125, 53);
            this.professionComboBox.Name = "professionComboBox";
            this.professionComboBox.Size = new System.Drawing.Size(158, 24);
            this.professionComboBox.TabIndex = 3;
            // 
            // raceComboBox
            // 
            this.raceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceComboBox.FormattingEnabled = true;
            this.raceComboBox.Items.AddRange(new object[] {
            "Dwarf",
            "Elf",
            "Gnome",
            "Half Elf",
            "Human"});
            this.raceComboBox.Location = new System.Drawing.Point(125, 83);
            this.raceComboBox.Name = "raceComboBox";
            this.raceComboBox.Size = new System.Drawing.Size(158, 24);
            this.raceComboBox.TabIndex = 5;
            // 
            // raceLabel
            // 
            this.raceLabel.AutoSize = true;
            this.raceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raceLabel.Location = new System.Drawing.Point(69, 86);
            this.raceLabel.Name = "raceLabel";
            this.raceLabel.Size = new System.Drawing.Size(50, 17);
            this.raceLabel.TabIndex = 4;
            this.raceLabel.Text = "Race:";
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strengthLabel.Location = new System.Drawing.Point(44, 115);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(75, 17);
            this.strengthLabel.TabIndex = 6;
            this.strengthLabel.Text = "Strength:";
            // 
            // strengthNumericUpDown
            // 
            this.strengthNumericUpDown.Location = new System.Drawing.Point(125, 113);
            this.strengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.strengthNumericUpDown.Name = "strengthNumericUpDown";
            this.strengthNumericUpDown.Size = new System.Drawing.Size(157, 22);
            this.strengthNumericUpDown.TabIndex = 7;
            this.strengthNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // intelligenceNumericUpDown
            // 
            this.intelligenceNumericUpDown.Location = new System.Drawing.Point(126, 141);
            this.intelligenceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intelligenceNumericUpDown.Name = "intelligenceNumericUpDown";
            this.intelligenceNumericUpDown.Size = new System.Drawing.Size(157, 22);
            this.intelligenceNumericUpDown.TabIndex = 9;
            this.intelligenceNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // intelligenceLabel
            // 
            this.intelligenceLabel.AutoSize = true;
            this.intelligenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelligenceLabel.Location = new System.Drawing.Point(23, 143);
            this.intelligenceLabel.Name = "intelligenceLabel";
            this.intelligenceLabel.Size = new System.Drawing.Size(96, 17);
            this.intelligenceLabel.TabIndex = 8;
            this.intelligenceLabel.Text = "Intelligence:";
            // 
            // agilityNumericUpDown
            // 
            this.agilityNumericUpDown.Location = new System.Drawing.Point(126, 169);
            this.agilityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.agilityNumericUpDown.Name = "agilityNumericUpDown";
            this.agilityNumericUpDown.Size = new System.Drawing.Size(157, 22);
            this.agilityNumericUpDown.TabIndex = 11;
            this.agilityNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // agilityLabel
            // 
            this.agilityLabel.AutoSize = true;
            this.agilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agilityLabel.Location = new System.Drawing.Point(62, 171);
            this.agilityLabel.Name = "agilityLabel";
            this.agilityLabel.Size = new System.Drawing.Size(57, 17);
            this.agilityLabel.TabIndex = 10;
            this.agilityLabel.Text = "Agility:";
            // 
            // constitutionNumericUpDown
            // 
            this.constitutionNumericUpDown.Location = new System.Drawing.Point(126, 197);
            this.constitutionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.constitutionNumericUpDown.Name = "constitutionNumericUpDown";
            this.constitutionNumericUpDown.Size = new System.Drawing.Size(157, 22);
            this.constitutionNumericUpDown.TabIndex = 13;
            this.constitutionNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // constitutionLabel
            // 
            this.constitutionLabel.AutoSize = true;
            this.constitutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constitutionLabel.Location = new System.Drawing.Point(20, 197);
            this.constitutionLabel.Name = "constitutionLabel";
            this.constitutionLabel.Size = new System.Drawing.Size(99, 17);
            this.constitutionLabel.TabIndex = 12;
            this.constitutionLabel.Text = "Constitution:";
            // 
            // charismaNumericUpDown
            // 
            this.charismaNumericUpDown.Location = new System.Drawing.Point(126, 225);
            this.charismaNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.charismaNumericUpDown.Name = "charismaNumericUpDown";
            this.charismaNumericUpDown.Size = new System.Drawing.Size(157, 22);
            this.charismaNumericUpDown.TabIndex = 15;
            this.charismaNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // charismaLabel
            // 
            this.charismaLabel.AutoSize = true;
            this.charismaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charismaLabel.Location = new System.Drawing.Point(39, 227);
            this.charismaLabel.Name = "charismaLabel";
            this.charismaLabel.Size = new System.Drawing.Size(80, 17);
            this.charismaLabel.TabIndex = 14;
            this.charismaLabel.Text = "Charisma:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(125, 253);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(158, 22);
            this.descriptionTextBox.TabIndex = 17;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(24, 253);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(95, 17);
            this.descriptionLabel.TabIndex = 16;
            this.descriptionLabel.Text = "Description:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(124, 281);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(158, 40);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(124, 325);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(158, 40);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CreateCharacterForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(323, 393);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.charismaNumericUpDown);
            this.Controls.Add(this.charismaLabel);
            this.Controls.Add(this.constitutionNumericUpDown);
            this.Controls.Add(this.constitutionLabel);
            this.Controls.Add(this.agilityNumericUpDown);
            this.Controls.Add(this.agilityLabel);
            this.Controls.Add(this.intelligenceNumericUpDown);
            this.Controls.Add(this.intelligenceLabel);
            this.Controls.Add(this.strengthNumericUpDown);
            this.Controls.Add(this.strengthLabel);
            this.Controls.Add(this.raceComboBox);
            this.Controls.Add(this.raceLabel);
            this.Controls.Add(this.professionComboBox);
            this.Controls.Add(this.professionLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateCharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Character";
            ((System.ComponentModel.ISupportInitialize)(this.strengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelligenceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agilityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constitutionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charismaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox professionComboBox;
        private System.Windows.Forms.Label professionLabel;
        private System.Windows.Forms.ComboBox raceComboBox;
        private System.Windows.Forms.Label raceLabel;
        private System.Windows.Forms.NumericUpDown strengthNumericUpDown;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.NumericUpDown charismaNumericUpDown;
        private System.Windows.Forms.Label charismaLabel;
        private System.Windows.Forms.NumericUpDown constitutionNumericUpDown;
        private System.Windows.Forms.Label constitutionLabel;
        private System.Windows.Forms.NumericUpDown agilityNumericUpDown;
        private System.Windows.Forms.Label agilityLabel;
        private System.Windows.Forms.NumericUpDown intelligenceNumericUpDown;
        private System.Windows.Forms.Label intelligenceLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button cancelButton;
    }
}