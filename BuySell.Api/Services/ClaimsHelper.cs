using System.Security.Claims;

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

        public void SetEmail(ClaimsIdentity identity, string email)
        {
            if (identity != null && email != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, email));
            }
        }
    }
}