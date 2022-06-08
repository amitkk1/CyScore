using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WUApiLib;

namespace CyScore.Agent
{
    internal static class Policies
    {
        public static bool WindowsDefenderActive()
        {

            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                foreach (var virusChecker in instances)
                {
                    var virusCheckerName = virusChecker["displayName"];
                    if (virusCheckerName.Equals("Windows Defender"))
                    {
                        if (virusChecker["productState"] == "397568") //checks if windows defender is active
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool AntivirusInstalled()
        {
            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                if (instances.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool GuestAccountSafe()
        {
            var guestAccount = new PrincipalSearcher(new UserPrincipal(new PrincipalContext(ContextType.Machine)))
                .FindAll()
                .Single(a => a.Sid.IsWellKnown(WellKnownSidType.AccountGuestSid));

            if (guestAccount.SamAccountName == "Noguest")
            {
                return true;
            }
            return false;
        }

        public static bool WindowsUpdatedLately()
        {
            var auc = new AutomaticUpdates();

            DateTime? lastInstallationSuccessDateUtc = null;
            if (auc.Results.LastInstallationSuccessDate is DateTime)
                lastInstallationSuccessDateUtc = new DateTime(((DateTime)auc.Results.LastInstallationSuccessDate).Ticks, DateTimeKind.Utc);

            if (lastInstallationSuccessDateUtc is null || lastInstallationSuccessDateUtc.Value.AddMonths(3) < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        public static bool SafeFromUnquotedServices()
        {
            ServiceController[] services = ServiceController.GetServices();

            var unquotedServices = services.Select(GetServicePath)
                .Where(path => path.Contains(" ") &&
                !path.ToLower().StartsWith("c:\\windows") &&
                !path.StartsWith("\"") &&
                !path.EndsWith("\""));

            if (unquotedServices.Any())
            {
                return false;
            }
            return true;


            string GetServicePath(ServiceController service)
            {
                return Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\" + service.ServiceName, "ImagePath", string.Empty).ToString();
            }
        }

        public static bool StartupApplicationsCountLow()
        {
            RegistryKey onStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            int startupApplicationCount = onStartup.ValueCount;
            return startupApplicationCount <= 10;
        }

        public static bool WindowsDefenderExclusionsEmpty()
        {
            try
            {

                RegistryKey registryExclusionsPaths = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Defender\\Exclusions\\Paths");
                if (registryExclusionsPaths.ValueCount > 0)
                {
                    return false;
                }
            }
            catch (Exception e) { }
            return true;
        }
        
        public static bool LUAEnabled()
        {
            RegistryKey systemPoliciesReg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            int LUAEnabled = (int)systemPoliciesReg.GetValue("EnableLUA");
            return LUAEnabled > 0;
        }
    }
}
