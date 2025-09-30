using BuySell.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuySell.Api.Controllers
{
    [ApiController]
    [Route("[Products]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<Product> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
