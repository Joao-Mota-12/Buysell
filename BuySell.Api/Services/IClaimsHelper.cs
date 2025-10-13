using System.Security.Claims;

namespace BuySell.Api.Services
{
    public interface IClaimsHelper
    {
        public string GetEmail(ClaimsIdentity identity);

        public string GetRole(ClaimsIdentity identity);

        public void SetRole(ClaimsIdentity identity, string role);
    }
}
