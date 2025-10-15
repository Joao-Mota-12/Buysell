using BuySell.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BuySell.Api.Repositories
{
    public class ProductsRepository(BuySellDbContext context) : IProductsRepository
    {
        private readonly BuySellDbContext _context = context;

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByUserEmail(string email)
        {
            return await _context.Products.Where(product => product.Owner.Email == email).ToListAsync();
        }
    }
}