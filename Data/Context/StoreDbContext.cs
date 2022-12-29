using Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Data.Context
{
    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext() { }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            entity.HasData(
             new { Id = 1, Name = "Sports" },
             new { Id = 2, Name = "Foods" },
             new { Id = 3, Name = "Books" },
             new { Id = 4, Name = "Hats" }
            ));

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasData(
                new { Id = 1, Name = "World Cup Ball 2022", Description = "Adidas Al Rihla is official match ball of World Cup 2022", CategoryId = 1, PhotoUrl = "World Cup Ball.jpeg" },
                new { Id = 2, Name = "Pizza Hut", Description = "Margherita cheese", CategoryId = 2, PhotoUrl = "Pizza Hut.jpg" },
                new { Id = 3, Name = "Harry Potter", Description = "Harry Potter ve'Ha'Assir Me'Azkaban", CategoryId = 3, PhotoUrl = "Harry Potter.jpg" },
                new { Id = 4, Name = "Nike Hat", Description = "Nike Sportswear Heritage 86", CategoryId = 4, PhotoUrl = "Nike hat.jpg" });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
