using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Models
{
    public class StationModel
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string Hostname { get; set; }
        public string StationKey { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual List<StationPolicyModel> Policies { get; set; }
    }
}
