using CyScore.Views;

namespace CyScore.API.Interfaces
{
    public interface IAgentService
    {
        public Task Notify(AgentNotificationView notification);
    }
}
