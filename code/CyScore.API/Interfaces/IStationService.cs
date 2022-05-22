using CyScore.Views;

namespace CyScore.API.Interfaces
{
    public interface IStationService
    {
        public IEnumerable<StationBasicDetailsView> GetAllStations();

        public GeneralInfoView GetGeneralInfo();
        public StationView GetStation(int id);
    }
}
