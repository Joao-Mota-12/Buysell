using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuySell.Api.Models.Enums;

namespace BuySell.Api.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public ProductStatusEnum? Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("ProductsOwned")]
        public Profile Owner { get; set; } = null!;

        public ICollection<Order>? Orders { get; set; }
    }
}