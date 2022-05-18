﻿using CyScore.Data.Interfaces;
using CyScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Services
{
    internal class StationsDataAccessService : IStationsDataAccessService
    {
        private readonly CyScoreContext context;

        public StationsDataAccessService(CyScoreContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateStation(string key, string mac, string hostname, string ip)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException($"'{nameof(key)}' cannot be null or empty.", nameof(key));

            if (string.IsNullOrEmpty(mac))
                throw new ArgumentException($"'{nameof(mac)}' cannot be null or empty.", nameof(mac));

            if (string.IsNullOrEmpty(hostname))
                throw new ArgumentException($"'{nameof(hostname)}' cannot be null or empty.", nameof(hostname));

            if (string.IsNullOrEmpty(ip))
                throw new ArgumentException($"'{nameof(ip)}' cannot be null or empty.", nameof(ip));

            StationModel station = new()
            {
                StationKey = key,
                Hostname = hostname,
                Ip = ip,
                Mac = mac,
                LastUpdated = DateTime.Now,
                Policies = Array.Empty<StationPolicyModel>()
            };

            await context.Stations.AddAsync(station);
            await context.SaveChangesAsync();
        }

        public IEnumerable<string> GetStationPolicies(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));


            List<string>? policiesNames = context.Stations
                .Where(station => station.StationKey == key)
                .Join(
                    context.StationsPolicies,
                    station => station.Id,
                    stationPolicy => stationPolicy.StationId,
                    (station, stationPolicy) => new
                    {
                        stationPolicy.PolicyId
                    })
                .Join(
                    context.Policies,
                    stationPolicy => stationPolicy.PolicyId,
                    policy => policy.Id,
                    (stationPolicy, policy) => new
                    {
                        PolicyName = policy.Name,
                    })
                .Select(policy => policy.PolicyName)
                .ToList();

            return policiesNames;
        }

        public async Task InsertStationPolicy(string stationKey, string policyName, string status)
        {
            if (string.IsNullOrWhiteSpace(stationKey))
                throw new ArgumentException($"'{nameof(stationKey)}' cannot be null or whitespace.", nameof(stationKey));

            if (string.IsNullOrWhiteSpace(policyName))
                throw new ArgumentException($"'{nameof(policyName)}' cannot be null or whitespace.", nameof(policyName));

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException($"'{nameof(status)}' cannot be null or whitespace.", nameof(status));

            var policy = context.Policies.FirstOrDefault(policy => policy.Name == policyName);
            var station = context.Stations.FirstOrDefault(station => station.StationKey == stationKey);

            if (policy is null)
                throw new ArgumentException("Policy does not exists");

            if (station is null)
                throw new ArgumentException("Station does not exists");

            station.LastUpdated = DateTime.Now;

            var policyId = policy.Id;
            var stationId = station.Id;

            var stationPolicy = new StationPolicyModel()
            {
                PolicyId = policyId,
                StationId = stationId,
                Status = status
            };

            await context.StationsPolicies.AddAsync(stationPolicy);
            await context.SaveChangesAsync();
        }

        public bool StationKeyExists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

            return context.Stations.Any(s => s.StationKey == key);
        }

        public async Task UpdateStationPolicy(string stationKey, string policyName, string status)
        {
            if (string.IsNullOrWhiteSpace(stationKey))
                throw new ArgumentException($"'{nameof(stationKey)}' cannot be null or whitespace.", nameof(stationKey));

            if (string.IsNullOrWhiteSpace(policyName))
                throw new ArgumentException($"'{nameof(policyName)}' cannot be null or whitespace.", nameof(policyName));

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException($"'{nameof(status)}' cannot be null or whitespace.", nameof(status));

            var policy = context.Policies.FirstOrDefault(policy => policy.Name == policyName);
            var station = context.Stations.FirstOrDefault(station => station.StationKey == stationKey);

            if (policy is null)
                throw new ArgumentException("Policy does not exists");

            if (station is null)
                throw new ArgumentException("Station does not exists");

            var stationPolicy = context.StationsPolicies.
                FirstOrDefault(stationPolicy => stationPolicy.PolicyId == policy.Id && stationPolicy.StationId == station.Id);

            if (stationPolicy == null)
                throw new ArgumentException("Station policy not found");

            station.LastUpdated = DateTime.Now;
            stationPolicy.Status = status;
            await context.SaveChangesAsync();

        }
    }
}