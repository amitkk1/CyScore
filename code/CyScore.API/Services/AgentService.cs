using CyScore.API.Constants;
using CyScore.API.Interfaces;
using CyScore.Data.Interfaces;
using CyScore.Views;

namespace CyScore.API.Services
{
    public class AgentService : IAgentService
    {
        private readonly IStationsDataAccessService stationsService;

        public AgentService(IStationsDataAccessService stationsService)
        {
            this.stationsService = stationsService ?? throw new ArgumentNullException(nameof(stationsService));
        }

        public async Task Notify(AgentNotificationView notification)
        {
            bool stationExists = stationsService.StationKeyExists(notification.StationKey);
            if (!stationExists)
            {
                await stationsService.CreateStation(
                    notification.StationKey,
                    notification.Mac,
                    notification.Hostname,
                    notification.Ip);
            }

            IEnumerable<string>? existingPolicies = stationsService.GetStationPolicies(notification.StationKey);
            if (existingPolicies is null)
            {
                existingPolicies = new List<string>();
            }

            foreach (var policy in notification.Policies)
            {
                if (existingPolicies.Any(policyName => policyName == policy.PolicyName))
                {
                    await stationsService.UpdateStationPolicy(
                        notification.StationKey,
                        policy.PolicyName,
                        policy.IsOk ? StationPolicyStatus.OK : StationPolicyStatus.NOT_OK
                    );
                }
                else
                {
                    await stationsService.InsertStationPolicy(
                        notification.StationKey,
                        policy.PolicyName,
                        policy.IsOk ? StationPolicyStatus.OK : StationPolicyStatus.NOT_OK
                    );
                }
            }


        }
    }
}
