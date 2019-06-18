using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS_interaction
{
    public partial class PasswordPromptForm : Form
    {
        public PasswordPromptForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }

        public void SetUsername(string username)
        {
            passwordLabel.Text = "Enter the password for " + username;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PasswordPromptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
                DialogResult = DialogResult.Cancel;
        }

        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckbox.Checked;
        }

        public string getPassword()
        {
            return passwordTextBox.Text;
        }

        private void JoinDomainButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "")
                MessageBox.Show("The password can not be empty.");
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
