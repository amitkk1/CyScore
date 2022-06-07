using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Agent
{
    internal static class PcInfo
    {
        public static string GetHostname()
        {
            string hostname = Dns.GetHostName();
            return hostname;
        }

        public static string GetIpAddress()
        {
            string hostname = Dns.GetHostName();
            string ip = Dns.GetHostByName(hostname).AddressList[0].ToString();
            return ip;
        }

        public static string GetMacAddress()
        {
            string macAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

            return macAddress;
        }

        public static string GetStationKey()
        {
            return ConfigurationManager.AppSettings.Get("StationKey");
        }
    }
}
