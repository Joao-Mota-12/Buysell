using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace BuySell.Api.Services
{
    public class ClaimsHelper : IClaimsHelper
    {
        public const string RoleClaimId = "http://schemas.buysell.com/ws/2008/06/identity/role";


        public string GetEmail(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                return identity.FindFirst(ClaimTypes.Email)?.Value;
            }

            return null;
        }

        public string GetRole(ClaimsIdentity identity)
        {
            if(identity != null)
            {
                //foreach (var claim in identity.Claims)
                //{
                //}
                var x = identity.FindFirst(RoleClaimId)?.Value;
                return x;

            }
            return null;
        }

        public void SetRole(ClaimsIdentity identity, string role)
        {
            if (identity != null && role != null)
            {
                identity.AddClaim(new Claim(RoleClaimId, role));
            }
        }
    }
}