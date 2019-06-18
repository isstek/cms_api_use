using System;
using System.Net;
using System.Management;
using System.Runtime.InteropServices;

namespace JoinDomain
{
    public class AddToDomain
    {
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        private IPAddress _dns;
        private string _name;
        private string _long_name;
        private string _admin_user;
        private string _admin_password;

        private int _connect_to_domain_result;

        public AddToDomain(IPAddress dnsip, string domain_name, string domain_name_long, string admin_user)
        {
            _dns = dnsip;
            _name = domain_name;
            _long_name = domain_name_long;
            _admin_password = "";
            _admin_user = admin_user;
        }

        public string Password
        {
            set
            {
                _admin_password = value;
            }
        }

        public string fullAdminUsername
        {
            get
            {
                return _name + "\\" + _admin_user;
            }
        }

        private void SetDnsConfig(bool resetall = true)
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    if (resetall || mo["DefaultIPGateway"] != null)
                    {
                        ManagementBaseObject DnsEntry = mo.GetMethodParameters("SetDNSServerSearchOrder");
                        DnsEntry["DNSServerSearchOrder"] = new string[] { _dns.ToString(), "8.8.8.8" };
                        ManagementBaseObject DnsMbo = mo.InvokeMethod("SetDNSServerSearchOrder", DnsEntry, null);
                        int returnCode = int.Parse(DnsMbo["returnvalue"].ToString());
                    }
                }
            }
            for (int i = 0; i < 4; ++i)
                DnsFlushResolverCache().ToString();
        }

        public string ErrorText
        {
            get
            {
                switch (_connect_to_domain_result)
                {
                    case 0:
                        return "Success";
                    case 5:
                        return "Access is denied. Please run software as administrator.";
                    case 87:
                        return "One of the parameters is incorrect.";
                    case 110:
                        return "Could not access the specified object.";
                    case 1323:
                        return "Unable to update the password.";
                    case 1326:
                        return "Logon failure: unknown username or bad password.";
                    case 1355:
                        return "Specified domain does not exist or could not be contacted.";
                    case 2224:
                        return "The account already exists.";
                    case 2691:
                        return "The machine is already joined the domain.";
                    case 2692:
                        return "The machine is not currently joined the domain.";
                    default:
                        return "Unknow error";
                }
            }
        }

        private bool LeaveDomain()
        {
            // Invoke WMI to join the domain
            using (ManagementObject wmiObject = new ManagementObject(new ManagementPath("Win32_ComputerSystem.Name='" + System.Environment.MachineName + "'")))
            {
                try
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams = wmiObject.GetMethodParameters("UnJoinDomainOrWorkgroup");

                    inParams["FJoinOptions"] = 0;

                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = wmiObject.InvokeMethod("JoinDomainOrWorkgroup", inParams, null);

                    //_connect_to_domain_result = (int)outParams["ReturnValue"];

                    return (int)outParams["ReturnValue"] == 0;
                }
                catch (ManagementException e)
                {
                    //_connect_to_domain_result = 4;
                    return false;
                }
            }
        }

        private bool EnterDomain()
        {
            // Invoke WMI to join the domain
            using (ManagementObject wmiObject = new ManagementObject(new ManagementPath("Win32_ComputerSystem.Name='" + System.Environment.MachineName + "'")))
            {
                try
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams = wmiObject.GetMethodParameters("JoinDomainOrWorkgroup");

                    inParams["Name"] = _long_name;
                    inParams["Password"] = _admin_password;
                    inParams["UserName"] = fullAdminUsername;
                    inParams["FJoinOptions"] = 3; // Magic number: 3 = join to domain and create computer account

                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = wmiObject.InvokeMethod("JoinDomainOrWorkgroup", inParams, null);

                    _connect_to_domain_result = (int)outParams["ReturnValue"];

                    return _connect_to_domain_result == 0;
                }
                catch (ManagementException e)
                {
                    _connect_to_domain_result = 4;
                    return false;
                }
            }
        }

        public bool joinDomain()
        {
            SetDnsConfig();
            if (System.Environment.UserDomainName != "")
                LeaveDomain();
            return EnterDomain();
        }
    }
}
