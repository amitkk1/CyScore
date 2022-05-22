using CyScore.API.Interfaces;
using CyScore.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyScore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationService stationService;

        public StationsController(IStationService stationService)
        {
            this.stationService = stationService ?? throw new ArgumentNullException(nameof(stationService));
        }

        [HttpGet("")]
        [Authorize]
        public ActionResult<IEnumerable<StationBasicDetailsView>> GetAllStations()
        {
            var stations = stationService.GetAllStations();
            return Ok(stations);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<IEnumerable<StationView>> GetStation(int id)
        {
            var station = stationService.GetStation(id);
            return Ok(station);
        }
    }
}
