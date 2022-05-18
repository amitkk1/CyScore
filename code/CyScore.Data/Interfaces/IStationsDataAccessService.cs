using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Interfaces
{
    public interface IStationsDataAccessService
    {
        /// <summary>
        /// Checks if a station key exists in the database
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True if found, false otherwise</returns>
        public bool StationKeyExists(string key);

        /// <summary>
        /// Creates new station in the database
        /// </summary>
        /// <param name="key">The unique key of the station</param>
        /// <param name="mac">mac address of the station</param>
        /// <param name="hostname">hostname of the station</param>
        /// <param name="ip">ip address of the station</param>
        public Task CreateStation(string key, string mac, string hostname, string ip);

        /// <summary>
        /// Gets station policies by station key
        /// </summary>
        /// <param name="key">Station key</param>
        /// <returns>Names of the existing policies</returns>
        public IEnumerable<string> GetStationPolicies(string key);

        public Task UpdateStationPolicy(string stationKey, string policyName, string status);

        public Task InsertStationPolicy(string stationKey, string policyName, string status);
    }
}
