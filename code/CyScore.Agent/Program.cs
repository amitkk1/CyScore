using CyScore.Views;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace CyScore.Agent
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string hostname = PcInfo.GetHostname();
            string ip = PcInfo.GetIpAddress();
            string mac = PcInfo.GetMacAddress();
            string stationKey = PcInfo.GetStationKey();
            string notificationURL = ConfigurationManager.AppSettings.Get("NotificationURL");

            var notificationBuilder = AgentNotificationBuilder.Builder
                .SetHostname(hostname)
                .SetIpAddress(ip)
                .SetMacAddress(mac)
                .SetStationKey(stationKey);

            //policies
            notificationBuilder
                .AddPolicy("Windows Defender", Policies.WindowsDefenderActive)
                .AddPolicy("Antivirus", Policies.AntivirusInstalled)
                .AddPolicy("Guest Account", Policies.GuestAccountSafe)
                .AddPolicy("Unquoted Services", Policies.SafeFromUnquotedServices)
                .AddPolicy("Startup Applications", Policies.StartupApplicationsCountLow)
                .AddPolicy("Windows Defender Exclusions", Policies.WindowsDefenderExclusionsEmpty)
                .AddPolicy("Windows UAC", Policies.LUAEnabled);

            AgentNotificationView notification = notificationBuilder.Build();
            await NotificationSender.Send(notificationURL, notification);
        }
    }
}

