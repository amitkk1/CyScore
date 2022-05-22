using CyScore.API.Interfaces;
using CyScore.Data.Interfaces;
using CyScore.Views;

namespace CyScore.API.Services
{
    public class StationService : IStationService
    {
        private readonly IStationsDataAccessService stationsDataAccessService;

        public StationService(IStationsDataAccessService stationsDataAccessService)
        {
            this.stationsDataAccessService = stationsDataAccessService ?? throw new ArgumentNullException(nameof(stationsDataAccessService));
        }
        public IEnumerable<StationBasicDetailsView> GetAllStations()
        {
            var result = stationsDataAccessService.GetAllStations();
            return result;
        }

        public GeneralInfoView GetGeneralInfo()
        {
            var stations = GetAllStations();

            var totalStations = stations.Count();
            var totalOkStations = stations.Count(s => s.AlertsCount == 0);
            var totalFaultyStations = totalStations - totalOkStations;
            var totalStationsNotCommunicating = stations.Count(s => s.LastUpdated.AddDays(2) < DateTime.Now);
            var totalActiveStations = totalStations - totalStationsNotCommunicating;
            var networkScore = stations.Sum(a => a.Score) /  totalStations;

            return new GeneralInfoView
            {
                TotalStations = totalStations,
                TotalOkStations = totalOkStations,
                TotalFaultyStations = totalFaultyStations,
                TotalActiveStations = totalActiveStations,
                TotalStationsNotCommunicating = totalStationsNotCommunicating,
                NetworkScore = (int)networkScore
            };
        }

        public StationView GetStation(int id)
        {
            return stationsDataAccessService.GetStation(id);
        }
    }
}
