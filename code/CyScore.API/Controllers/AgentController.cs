using CyScore.API.Interfaces;
using CyScore.Views;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CyScore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService ?? throw new ArgumentNullException(nameof(agentService));
        }

        [HttpPost]
        public async Task<ActionResult> NotifyAsync([FromBody]AgentNotificationView notification)
        {
            await agentService.Notify(notification);
            return Ok();
        }
    }
}
