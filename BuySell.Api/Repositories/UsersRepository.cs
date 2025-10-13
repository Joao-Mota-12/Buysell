using BuySell.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BuySell.Api.Repositories
{
    public class UsersRepository(BuySellDbContext dbContext) : IUsersRepository
    {
        private readonly BuySellDbContext _dbContext = dbContext;

        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        {

            return await _dbContext.Users
                .Include(u => u.Profile)
                .ThenInclude(p => p.ProfileType)
                .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        }
    }
}
