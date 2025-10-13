using BuySell.Api.Services;
using System.Security.Claims;

namespace BuySell.Api.Middleware
{
    public class ClaimBuilderMiddleware
    {
        private readonly RequestDelegate _next;

        public ClaimBuilderMiddleware(RequestDelegate next)
        {
           _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IClaimsHelper _claimsHelper = context.RequestServices.GetRequiredService<IClaimsHelper>();
            IUsersService _userService = context.RequestServices.GetRequiredService<IUsersService>();

            var identity = context.User.Identity as ClaimsIdentity;

            var email = _claimsHelper.GetEmail(identity);

            var user = await _userService.GetUserByEmail(email);

            if(user != null)
            {
                _claimsHelper.SetRole(identity, user.Profile.ProfileType.Code);
            }
            
            await _next(context);
        }
    }
}