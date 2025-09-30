using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuySell.Api.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string KeycloakId { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        [Required]
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; } = null!;
        public ICollection<Order>? Orders { get; set; }
    }
}