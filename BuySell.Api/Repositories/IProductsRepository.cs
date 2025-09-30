using BuySell.Api.Models;

namespace BuySell.Api.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

    }
}
