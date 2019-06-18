using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CMSServerConnect;
using System.Text;
using System.Windows.Forms;
using JoinDomain;

namespace CMS_interaction
{
    public partial class AddComputerToDomain : Form
    {
        SettingsKeeper serverConnectSettings;
        CMSConnector cmsconnector;
        InfoPreviewForm infoForm = null;
        DomainClass domainInfo = null;

        public AddComputerToDomain()
        {
            serverConnectSettings = new SettingsKeeper();
            cmsconnector = new CMSConnector(serverConnectSettings.Api_key, serverConnectSettings.Server_name);
            InitializeComponent();
            List<ClientClass> clients = cmsconnector.GetDomainClients();
            if (clients != null)
                chooseClientCombobox.Items.AddRange(clients.ToArray());
        }
        private DataGridViewRow generateRow(string name, string value)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = name });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = value });
            return row;
        }

        private void GetInfo()
        {
            if (domainInfo == null)
                domainInfo = cmsconnector.GetDomainInfo(((ClientClass)chooseClientCombobox.SelectedItem));
        }

        private void ShowInformationButton_Click(object sender, EventArgs e)
        {
            GetInfo();
            if (infoForm != null)
                infoForm.Close();
            infoForm = new InfoPreviewForm();
            infoForm.AddColumns(new string[,] { { "ParameterColumn", "Parameter" }, { "ValueColumn", "Value" } });
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            rows.Add(generateRow("Domain name", domainInfo.domain));
            rows.Add(generateRow("Long domain name", domainInfo.domain_long));
            rows.Add(generateRow("Admin username", domainInfo.admin));
            rows.Add(generateRow("DNS IP", domainInfo.dns));
            infoForm.AddInfo(rows.ToArray());
            infoForm.Show();
        }

        private void ChooseClientCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseClientCombobox.SelectedItem != null)
            {
                showInformationButton.Enabled = true;
                addComputerButton.Enabled = true;
                domainInfo = null;
            }

        }

        private void AddComputerButton_Click(object sender, EventArgs e)
        {
            GetInfo();
            AddToDomain addToDomain = new AddToDomain(domainInfo.IP, domainInfo.domain, domainInfo.domain_long, domainInfo.admin);
            PasswordPromptForm passwordForm = new PasswordPromptForm();
            passwordForm.SetUsername(addToDomain.fullAdminUsername);
            if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                addToDomain.Password = passwordForm.getPassword();
                if (addToDomain.joinDomain())
                {
                    MessageBox.Show("The computer was add to the domain! You can restart now.");
                    Close();
                }
                else
                {
                    MessageBox.Show("There was an error. " + addToDomain.ErrorText);
                }
            }
        }
    }
}
