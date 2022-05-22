using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Views
{
    public class StationView : StationBasicDetailsView
    {
        public StationPolicyView[] Policies { get; set; }
    }
}
