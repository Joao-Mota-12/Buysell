using BuySell.Api.Models;

namespace BuySell.Api.Services
{
    public interface IUsersService
    {
        public Task<User> GetUserByEmail(string email);
    }
}
