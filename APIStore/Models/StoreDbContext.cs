using Microsoft.EntityFrameworkCore;
using System;

namespace APIStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Categories!)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customers>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customers!)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Orders!)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Products>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Products!)
                .HasForeignKey(oi => oi.ProductId);
        }
    }
}
