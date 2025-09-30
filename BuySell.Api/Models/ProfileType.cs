using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuySell.Api.Models
{
        [Table("ProfileTypes")]
        public class ProfileType
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; } = string.Empty;

            [StringLength(255)]
            public string? Description { get; set; }

            public ICollection<Profile>? Profiles { get; set; }
    }
}