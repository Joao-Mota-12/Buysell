using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuySell.Api.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ProfileType")]
        public int ProfileTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; } = string.Empty;
        public ProfileType ProfileType { get; set; } = null!;
        public ICollection<User>? Users { get; set; }
        public ICollection<Product>? ProductsOwned { get; set; }
    }
}