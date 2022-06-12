using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Models
{
    public class StationPolicyModel
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int StationId { get; set; }
        public DateTime LastChanged { get; set; }
        public virtual PolicyModel Policy { get; set; }
        public virtual StationModel Station { get; set; }
        public string Status { get; set; }
    }
}
