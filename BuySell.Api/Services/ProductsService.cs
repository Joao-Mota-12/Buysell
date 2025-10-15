using BuySell.Api.Models;
using BuySell.Api.Repositories;

namespace BuySell.Api.Services
{
    public class ProductsService(IProductsRepository productsRepository) : IProductsService
    {
        private readonly IProductsRepository _productsRepository = productsRepository;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByOwnerEmail(string email)
        {
            return await _productsRepository.GetAllByUserEmail(email);
        }
    }
}
