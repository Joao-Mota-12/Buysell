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
            modelBuilder.Entity<ProfileType>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.ProfileType)
                .HasForeignKey(p => p.ProfileTypeId);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Users)
                .WithOne(u => u.Profile)
                .HasForeignKey(u => u.ProfileId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Buyer);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ProductsOwned)
                .WithOne(pO => pO.Owner)
                .HasForeignKey(pO => pO.OwnerId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Buyer)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.BuyerId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Product)
            //    .WithMany(p => p.Orders)
            //    .HasForeignKey(o => o.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
