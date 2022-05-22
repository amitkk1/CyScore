using CyScore.API.Interfaces;
using CyScore.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyScore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IStationService stationService;

        public InfoController(IStationService stationService)
        {
            this.stationService = stationService ?? throw new ArgumentNullException(nameof(stationService));
        }

        [HttpGet("")]
        [Authorize]
        public ActionResult<GeneralInfoView> GetGeneralInfo()
        {
            var info = stationService.GetGeneralInfo();
            return Ok(info);
        }
    }
}
