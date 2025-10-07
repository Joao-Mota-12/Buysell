using BuySell.Api.Models;
using BuySell.Api.Repositories;

namespace BuySell.Api.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public async Task<User> GetUserByEmail(string email)
        {
            return await _usersRepository.GetByEmail(email, CancellationToken.None);
        }
    }
}
