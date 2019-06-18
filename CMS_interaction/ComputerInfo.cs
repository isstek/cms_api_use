using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Management;
using System.Windows.Forms;


namespace CMS_interaction
{
    public class ComputerInfo
    {
        const string COMPUTERNAME_POST_KEY = "computername";
        const string MODEL_POST_KEY = "model";
        const string SERIAL_NUMBER_POST_KEY = "serialnumber";
        const string MANUFACTURER_POST_KEY = "manuf";
        const string YEAR_POST_KEY = "year";
        const string MONTH_POST_KEY = "month";
        const string IP_TYPE_POST_KEY = "iptype";
        const string IP_ADDRESS_POST_KEY = "ipaddress";
        const string MAC_ADDRESS_POST_KEY = "macaddress";
        const string CONNECTION_TYPE_POST_KEY = "contype";
        const string OS_VERSION_POST_KEY = "opsystem";

        static readonly string[,] OPERATING_SYSTEM_CONSTANTS_SEARCH = { { "2003", "WS03" }, { "2008", "WS08" }, { "2011", "WS08" },
            { "2012", "WS12" }, { "2016", "WS16" }, {"2019", "WS19" }, {"xp", "WXP" }, {"7", "W7" }, {"8.1", "W8" }, {"8", "W8" },
            {"10", "W10" } };

        static readonly string[,] MANUFACTURER_CONSTANTS_SEARCH = { { "dell", "D" }, {"hp", "H" }, {"hewlett", "H"}, {"lenovo", "L"},
            {"microsoft", "M"}, {"apple", "G" }, {"asus", "A" }, {"sony", "S" }, {"acer", "C" } };


        string _computer_name="", _model="", _serialnumber = "", _manufacturer = "", _iptype = "", _ipaddress = "", 
            _macaddress = "", _connection_type = "", _operating_system_version = "";
        bool _gathered_info = false;

        public string computerName
        {
            get
            {
                CollectComputerInfo();
                return _computer_name;
            }
        }

        public string model
        {
            get
            {
                CollectComputerInfo();
                return _model;
            }
        }

        public string serialNumber
        {
            get
            {
                CollectComputerInfo();
                return _serialnumber;
            }
        }

        public string manufacturer
        {
            get
            {
                CollectComputerInfo();
                return _manufacturer;
            }
        }

        public string IPType
        {
            get
            {
                CollectComputerInfo();
                return _iptype;
            }
        }

        public string connectionType
        {
            get
            {
                CollectComputerInfo();
                return _connection_type;
            }
        }

        public string IPAddress
        {
            get
            {
                CollectComputerInfo();
                return _ipaddress;
            }
        }

        public string macAddress
        {
            get
            {
                CollectComputerInfo();
                return _macaddress;
            }
        }

        public string OSVersion
        {
            get
            {
                CollectComputerInfo();
                return _operating_system_version;
            }
        }



        string friendly_manufacturer()
        {
            string manuf = _manufacturer.ToLower();
            for (int i = 0; i < MANUFACTURER_CONSTANTS_SEARCH.GetLength(0); ++i)
            {
                if (manuf.IndexOf(MANUFACTURER_CONSTANTS_SEARCH[i, 0]) != -1)
                    return MANUFACTURER_CONSTANTS_SEARCH[i, 1];
            }
            return "O";
        }


        string get_os_version()
        {
            string long_caption = _operating_system_version.ToLower();
            for (int i = 0; i < OPERATING_SYSTEM_CONSTANTS_SEARCH.GetLength(0); ++i)
            {
                if (long_caption.IndexOf(OPERATING_SYSTEM_CONSTANTS_SEARCH[i, 0]) != -1)
                    return OPERATING_SYSTEM_CONSTANTS_SEARCH[i, 1];
            }
            return "WO";
        }

        string friendly_iptype()
        {
            switch (_iptype)
            {
                case "D":
                    return "Dynamic";
                case "S":
                    return "Static";
                default:
                    return "";

            }
        }

        string friendly_connection_type()
        {
            switch (_connection_type)
            {
                case "W":
                    return "WiFi";
                case "E":
                    return "Ethernet";
                default:
                    return "";

            }
        }


        public Dictionary<string, string> GetComputerInfo()
        {
            if (!_gathered_info)
                CollectComputerInfo();
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (_manufacturer != "")
                result.Add(MANUFACTURER_POST_KEY, friendly_manufacturer());
            if (_model != "")
                result.Add(MODEL_POST_KEY, _model);
            if (_serialnumber != "")
                result.Add(SERIAL_NUMBER_POST_KEY, _serialnumber);
            if (_operating_system_version != "")
                result.Add(OS_VERSION_POST_KEY, get_os_version());
            result.Add(COMPUTERNAME_POST_KEY, _computer_name);
            if (_connection_type != "")
                result.Add(CONNECTION_TYPE_POST_KEY, _connection_type);
            if (_macaddress != "")
                result.Add(MAC_ADDRESS_POST_KEY, _macaddress);
            if (_iptype != "")
                result.Add(IP_TYPE_POST_KEY, _iptype);
            if (_ipaddress != "")
                result.Add(IP_ADDRESS_POST_KEY, _ipaddress);

            return result;
        }

        private string friendly_mac()
        {
            List<string> list = Enumerable
                .Range(0, _macaddress.Length / 2)
                .Select(i => _macaddress.Substring(i * 2, 2))
                .ToList();
            return string.Join(":", list);
        }

        private DataGridViewRow generateRow(string name, string value)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = name });
            row.Cells.Add(new DataGridViewTextBoxCell() { Value = value });
            return row;
        }

        public List<DataGridViewRow> GetComputerInfoTable()
        {
            if (!_gathered_info)
                CollectComputerInfo();
            List<DataGridViewRow> result = new List<DataGridViewRow>();
            result.Add(generateRow("Computer name", _computer_name));
            if (_model != "")
                result.Add(generateRow("Computer model", _model));
            if (_serialnumber != "")
                result.Add(generateRow("Serial number", _serialnumber));
            if (_manufacturer != "")
                result.Add(generateRow("Manufacturer", _manufacturer));
            if (_iptype != "")
                result.Add(generateRow("IP type", friendly_iptype()));
            if (_ipaddress != "")
                result.Add(generateRow("IP address", _ipaddress));
            if (_macaddress != "")
                result.Add(generateRow("Mac address", friendly_mac()));
            if (_connection_type != "")
                result.Add(generateRow("Connection type", friendly_connection_type()));
            if (_operating_system_version != "")
                result.Add(generateRow("Operating system", _operating_system_version));

            return result;
        }


        public void CollectComputerInfo()
        {
            if (_gathered_info)
                return;
            _computer_name = Environment.MachineName;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                try
                {
                    _model = obj["Model"].ToString().Trim();
                }
                catch { }
            }
            searcher = new ManagementObjectSearcher("SELECT SerialNumber, Manufacturer, ReleaseDate FROM Win32_BIOS");
            information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                try
                {
                    _serialnumber = obj["SerialNumber"].ToString().Trim();
                }
                catch { }
                try
                {
                    _manufacturer = obj["Manufacturer"].ToString().Trim();
                }
                catch { }
                try
                {
                    //result.Add(YEAR_POST_KEY, obj["ReleaseDate"].ToString().Trim().Substring(0, 4));
                }
                catch { }
                try
                {
                    //result.Add(MONTH_POST_KEY, obj["ReleaseDate"].ToString().Trim().Substring(4, 2));
                }
                catch { }
            }

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    IPInterfaceProperties ipprop = nic.GetIPProperties();
                    if (ipprop.GatewayAddresses.Count > 0)
                    {
                        if (ipprop.DhcpServerAddresses.Count > 0)
                            try
                            {
                                _iptype = "D";
                            }
                            catch { }
                        else
                        {
                            try
                            {
                                _iptype = "S";
                            }
                            catch { }
                            foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                            {
                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                {
                                    try
                                    {
                                        _ipaddress = ip.Address.ToString();
                                    }
                                    catch { }
                                }
                            }
                        }
                        try
                        {
                            _macaddress = nic.GetPhysicalAddress().ToString();
                        }
                        catch { }

                        if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                            try
                            {
                                _connection_type = "W";
                            }
                            catch { }
                        else
                            try
                            {
                                _connection_type = "E";
                            }
                            catch { }

                    }
                }
            }

            searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                try
                {
                    _operating_system_version = obj["Caption"].ToString().Trim();
                }
                catch { }
            }
            _gathered_info = true;
        }
    }
}
