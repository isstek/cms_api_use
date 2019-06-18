namespace CMS_interaction
{
    partial class AddComputerToDomain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddComputerToDomain));
            this.showInformationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addComputerButton = new System.Windows.Forms.Button();
            this.chooseClientCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // showInformationButton
            // 
            this.showInformationButton.Enabled = false;
            this.showInformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showInformationButton.Location = new System.Drawing.Point(12, 12);
            this.showInformationButton.Name = "showInformationButton";
            this.showInformationButton.Size = new System.Drawing.Size(330, 23);
            this.showInformationButton.TabIndex = 1;
            this.showInformationButton.Text = "Show information";
            this.showInformationButton.UseVisualStyleBackColor = true;
            this.showInformationButton.Click += new System.EventHandler(this.ShowInformationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose client:";
            // 
            // addComputerButton
            // 
            this.addComputerButton.Enabled = false;
            this.addComputerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComputerButton.Location = new System.Drawing.Point(13, 84);
            this.addComputerButton.Name = "addComputerButton";
            this.addComputerButton.Size = new System.Drawing.Size(329, 23);
            this.addComputerButton.TabIndex = 6;
            this.addComputerButton.Text = "Add computer to domain";
            this.addComputerButton.UseVisualStyleBackColor = true;
            this.addComputerButton.Click += new System.EventHandler(this.AddComputerButton_Click);
            // 
            // chooseClientCombobox
            // 
            this.chooseClientCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseClientCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseClientCombobox.FormattingEnabled = true;
            this.chooseClientCombobox.Location = new System.Drawing.Point(12, 57);
            this.chooseClientCombobox.Name = "chooseClientCombobox";
            this.chooseClientCombobox.Size = new System.Drawing.Size(330, 21);
            this.chooseClientCombobox.Sorted = true;
            this.chooseClientCombobox.TabIndex = 5;
            this.chooseClientCombobox.SelectedIndexChanged += new System.EventHandler(this.ChooseClientCombobox_SelectedIndexChanged);
            // 
            // AddComputerToDomain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 117);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addComputerButton);
            this.Controls.Add(this.chooseClientCombobox);
            this.Controls.Add(this.showInformationButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddComputerToDomain";
            this.Text = "Add computer to domain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showInformationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addComputerButton;
        private System.Windows.Forms.ComboBox chooseClientCombobox;
    }
}