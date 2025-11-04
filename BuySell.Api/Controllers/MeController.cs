using BuySell.Api.Models;
using BuySell.Api.Repositories;
using BuySell.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuySell.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeController(IUsersRepository usersRepository, IClaimsHelper claimsHelper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var email = claimsHelper.GetEmail(identity);

            var user = await usersRepository.GetByEmail(email, cancellationToken);

            var role = claimsHelper.GetRole(identity);

            var me = new Me(user.Email, role);

            return Ok(me);
        } 
    }
}
