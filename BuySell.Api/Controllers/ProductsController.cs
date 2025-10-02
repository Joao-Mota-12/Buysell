using BuySell.Api.Models;
using BuySell.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.Api.Controllers
{
    [ApiController]
    [Route("api/produts")]
    [Authorize]
    public class ProductsController(IProductsService productsService) : ControllerBase
    {
        private readonly IProductsService _productsService = productsService;

        [HttpGet(Name = "GetAllProducts")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productsService.GetAllProductsAsync();

            return Ok(products);
        }
    }
}