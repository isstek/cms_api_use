using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMSServerConnect;

namespace CMS_interaction
{
    public partial class AddComputerToCMS : Form
    {
        SettingsKeeper serverConnectSettings;
        CMSConnector cmsconnector;
        ComputerInfo computerInfo;
        InfoPreviewForm infoForm = null;

        public AddComputerToCMS()
        {
            serverConnectSettings = new SettingsKeeper();
            cmsconnector = new CMSConnector(serverConnectSettings.Api_key, serverConnectSettings.Server_name);
            computerInfo = new ComputerInfo();
            InitializeComponent();
            List<ClientClass> clients = cmsconnector.GetAllClients();
            if (clients != null)
                chooseClientCombobox.Items.AddRange(clients.ToArray());
        }

        private void ChooseClientCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addComputerButton.Enabled = true;
        }

        private void AddComputerButton_Click(object sender, EventArgs e)
        {
            cmsconnector.SendComputerInfo(((ClientClass)chooseClientCombobox.SelectedItem).unid, computerInfo.GetComputerInfo());
        }

        private void ShowInformationButton_Click(object sender, EventArgs e)
        {
            if (infoForm != null)
                infoForm.Close();
            infoForm = new InfoPreviewForm();
            infoForm.AddColumns(new string[,] { { "ParameterColumn", "Parameter" }, { "ValueColumn", "Value" } });
            infoForm.AddInfo(computerInfo.GetComputerInfoTable().ToArray());
            infoForm.Show();
        }
    }
}
