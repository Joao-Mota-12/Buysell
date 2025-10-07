using BuySell.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BuySell.Api.Repositories
{
    public class UsersRepository(BuySellDbContext dcContext) : IUsersRepository
    {
        private readonly BuySellDbContext _dbContext;

        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        {

            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        }
    }
}
