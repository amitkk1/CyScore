using CyScore.API.Interfaces;
using CyScore.Data.Interfaces;
using CyScore.Views;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace CyScore.API.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration config;
        private readonly IUserDataAccessService userService;

        public UserService(IConfiguration config, IUserDataAccessService userService)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public bool AuthenticateUser(UserView user)
        {
            var salt = userService.GetSalt(user.UserName);
            var passwordHash = GeneratePasswordHash(user.Password, salt);
            var authenticated = userService.ValidateCredentials(user.UserName, passwordHash);
            return authenticated;
        }

        public string GenerateJsonWebToken(UserView user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credenticals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credenticals);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Signup(UserView user)
        {
            Random random = new();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string salt = new(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            byte[] hashedPassword = GeneratePasswordHash(user.Password, salt);
            await userService.CreateUser(user.UserName, salt, hashedPassword);
        }

        private byte[] GeneratePasswordHash(string password, string salt)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
