using BuySell.Api.Models;
using BuySell.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuySell.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductsController(IProductsService productsService) : ControllerBase
    {
        private readonly IProductsService _productsService = productsService;

        [HttpGet("all")]
        //[Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productsService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("seller")]
        //[Authorize(Policy = "SellerOrAdmin")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllByOwnerEmail()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            var products = await _productsService.GetAllProductsByOwnerEmail(email);

            return Ok(products);
        }
    }
}