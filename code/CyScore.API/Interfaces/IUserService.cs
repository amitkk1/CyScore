using CyScore.Views;

namespace CyScore.API.Interfaces
{
    public interface IUserService
    {
        public string GenerateJsonWebToken(UserView user);
        public bool AuthenticateUser(UserView user);
        public Task Signup(UserView user);
    }
}
