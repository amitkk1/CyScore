using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Views
{
    public class AgentNotificationView
    {
        public string StationKey { get; set; }
        public string Ip { get; set; }
        public string Hostname { get; set; }
        public string Mac { get; set; }
        public AgentNotificationPolicyView[] Policies { get; set; }
    }
}
