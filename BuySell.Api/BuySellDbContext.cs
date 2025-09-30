using BuySell.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BuySell.Api
{
    public class BuySellDbContext : DbContext
    {
    public BuySellDbContext(DbContextOptions<BuySellDbContext> options): base(options)
        {
        }

        public DbSet<ProfileType> ProfileTypes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Owner)
                .WithMany(pf => pf.ProductsOwned)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.BuyerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.KeycloakId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
