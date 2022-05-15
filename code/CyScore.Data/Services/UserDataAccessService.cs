using CyScore.Data.Interfaces;
using CyScore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyScore.Data.Services
{
    internal class UserDataAccessService : IUserDataAccessService
    {
        private readonly CyScoreContext context;

        public UserDataAccessService(CyScoreContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreateUser(string username, string salt, byte[] encryptedPassword)
        {

            if (string.IsNullOrEmpty(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            if (encryptedPassword is null) throw new ArgumentNullException(nameof(encryptedPassword));

            var userExists = context.Users.Any(a => a.Username == username);
            if (userExists)
            {
                throw new ArgumentException("Username already exists");
            }
            else
            {
                var user = new UserModel { Password = encryptedPassword, Username = username, Salt = salt };
                await context.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public string GetSalt(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));

            var user = context.Users.FirstOrDefault(a => a.Username == username);
            if(user is null) throw new ArgumentException("User does not exist");
            return user.Salt;
        }

        public bool ValidateCredentials(string username, byte[] encryptedPassword)
        {
            var user = context.Users.FirstOrDefault(a => a.Username == username && a.Password == encryptedPassword);
            if (user is null)
            {
                return false;
            }
            return true;
        }


    }
}
