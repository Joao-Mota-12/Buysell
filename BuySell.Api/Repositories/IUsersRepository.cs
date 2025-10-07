using BuySell.Api.Models;

namespace BuySell.Api.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);
    }
}