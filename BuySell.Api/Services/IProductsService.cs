using BuySell.Api.Models;

namespace BuySell.Api.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<IEnumerable<Product>> GetAllProductsByOwnerEmail(string email);
    }
}
