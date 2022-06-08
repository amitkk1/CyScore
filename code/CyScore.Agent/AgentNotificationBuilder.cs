using CyScore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Agent
{
    internal class AgentNotificationBuilder
    {
        List<AgentNotificationPolicyView> policies;
        string mac;
        string ip;
        string hostname;
        string stationKey;


        private AgentNotificationBuilder()
        {
            policies = new();
            mac = null;
            ip = null;
            hostname = null;
            stationKey = null;
        }

        public static AgentNotificationBuilder Builder => new AgentNotificationBuilder();

        public AgentNotificationBuilder SetMacAddress(string mac)
        {
            this.mac = mac;
            return this;
        }

        public AgentNotificationBuilder SetIpAddress(string ip)
        {
            this.ip = ip;
            return this;
        }

        public AgentNotificationBuilder SetHostname(string hostname)
        {
            this.hostname = hostname;
            return this;
        }

        public AgentNotificationBuilder SetStationKey(string stationKey)
        {
            this.stationKey = stationKey;
            return this;
        }

        public AgentNotificationBuilder AddPolicy(string policyName, Func<bool> policyExecutor)
        {
            bool isOk = policyExecutor.Invoke();
            policies.Add(new AgentNotificationPolicyView
            {
                PolicyName = policyName,
                IsOk = isOk
            });
            return this;
        }

        public AgentNotificationView Build()
        {
            return new AgentNotificationView()
            {
                Hostname = hostname,
                Ip = ip,
                Mac = mac,
                StationKey = stationKey,
                Policies = policies.ToArray()
            };
        }
    }
}
