using BuySell.Api.Models;
using BuySell.Api.Repositories;

namespace BuySell.Api.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        public async Task<User> GetUserByEmail(string email)
        {
            if(email != null)
            {
                return await _usersRepository.GetByEmail(email, CancellationToken.None);
            }
            return null;
        }
    }
}
