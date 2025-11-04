using BuySell.Api.Services;

namespace BuySell.Api.Models
{
    public class Me(string email, string role)
    {
        public string? Email { get; set; } = email;
        public bool IsAdmin { get; set; } = role == "ADMIN";
        public bool IsSeller { get; set; } = role == "SELLER";
        public bool IsBuyer { get; set; } = role == "BUYER";
    }
}
