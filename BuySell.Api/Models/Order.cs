using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BuySell.Api.Models.Enums;

namespace BuySell.Api.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public OrderStatusEnum? Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Orders")]
        public User Buyer { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}