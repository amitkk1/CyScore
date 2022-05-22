using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Views
{
    public class GeneralInfoView
    {
        public int TotalStations { get; set; }
        public int TotalActiveStations { get; set; }
        public int TotalStationsNotCommunicating { get; set; }
        public int TotalFaultyStations { get; set; }
        public int TotalOkStations { get; set; }
        public int NetworkScore { get; set; }
    }
}
