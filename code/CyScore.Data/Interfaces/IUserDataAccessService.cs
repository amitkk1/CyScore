using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Interfaces
{
    public interface IUserDataAccessService
    {
        /// <summary>
        /// Checks if user exists in the database
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="encryptedPassword">Password of the user</param>
        /// <returns>True if exists, false otherwise</returns>
        public bool ValidateCredentials(string username, byte[] encryptedPassword);

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="encryptedPassword">Password of the user</param>
        /// <param name="salt">Salt used to encrypt the password with</param>
        /// <exception cref="ArgumentNullException">When given a null argument</exception>
        /// <exception cref="ArgumentException">When given an invalid argument</exception>
        public Task CreateUser(string username, string salt, byte[] encryptedPassword);


        /// <summary>
        /// Gets a user's password salt by it's username
        /// </summary>
        /// <param name="username">Username to get the salt from</param>
        /// <returns>Requested user's salt</returns>
        /// <exception cref="ArgumentException">When given an invalid argument, such as a non-existing user</exception>
        public string GetSalt(string username);
    }
}
