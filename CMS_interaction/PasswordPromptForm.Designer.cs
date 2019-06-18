namespace CMS_interaction
{
    partial class PasswordPromptForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.showPasswordCheckbox = new System.Windows.Forms.CheckBox();
            this.joinDomainButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 30);
            this.passwordTextBox.MaxLength = 36;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(197, 20);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(13, 11);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(0, 13);
            this.passwordLabel.TabIndex = 1;
            // 
            // showPasswordCheckbox
            // 
            this.showPasswordCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showPasswordCheckbox.AutoSize = true;
            this.showPasswordCheckbox.Location = new System.Drawing.Point(215, 28);
            this.showPasswordCheckbox.Name = "showPasswordCheckbox";
            this.showPasswordCheckbox.Size = new System.Drawing.Size(44, 23);
            this.showPasswordCheckbox.TabIndex = 2;
            this.showPasswordCheckbox.Text = "Show";
            this.showPasswordCheckbox.UseVisualStyleBackColor = true;
            this.showPasswordCheckbox.CheckedChanged += new System.EventHandler(this.ShowPasswordCheckbox_CheckedChanged);
            // 
            // joinDomainButton
            // 
            this.joinDomainButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.joinDomainButton.Location = new System.Drawing.Point(118, 56);
            this.joinDomainButton.Name = "joinDomainButton";
            this.joinDomainButton.Size = new System.Drawing.Size(91, 23);
            this.joinDomainButton.TabIndex = 3;
            this.joinDomainButton.Text = "Join Domain";
            this.joinDomainButton.UseVisualStyleBackColor = false;
            this.joinDomainButton.Click += new System.EventHandler(this.JoinDomainButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 56);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PasswordPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(266, 89);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.joinDomainButton);
            this.Controls.Add(this.showPasswordCheckbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Name = "PasswordPromptForm";
            this.Text = "Enter password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordPromptForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckBox showPasswordCheckbox;
        private System.Windows.Forms.Button joinDomainButton;
        private System.Windows.Forms.Button cancelButton;
    }
}