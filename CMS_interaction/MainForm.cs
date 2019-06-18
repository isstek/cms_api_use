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

    public partial class MainForm : Form
    {
        AddComputerToCMS addComputerCMSForm = null;
        AddComputerToDomain addComputerDomainForm = null;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddComputerToCMSButton_Click(object sender, EventArgs e)
        {
            if (addComputerCMSForm != null)
                addComputerCMSForm.Close();
            addComputerCMSForm = new AddComputerToCMS();
            addComputerCMSForm.Show();
        }

        private void AddComputerToDomain_Click(object sender, EventArgs e)
        {
            if (addComputerDomainForm != null)
                addComputerDomainForm.Close();
            addComputerDomainForm = new AddComputerToDomain();
            addComputerDomainForm.Show();
        }
    }
}
