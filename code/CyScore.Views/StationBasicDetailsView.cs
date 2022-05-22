using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Views
{
    public class StationBasicDetailsView
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int AlertsCount { get; set; }
        public double Score { get; set; }
        public string Mac { get; set; }
        public string Hostname { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
