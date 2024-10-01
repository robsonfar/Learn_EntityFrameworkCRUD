using Learn_EntityFrameworkCRUD.Models;

using Microsoft.EntityFrameworkCore;

namespace Learn_EntityFrameworkCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Create Table
        public DbSet<ProductType> ProductType { get; set; }

        // Seed Table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Type 1" }
                , new ProductType { Id = 2, Name = "Type 2" }
                , new ProductType { Id = 3, Name = "Type 3" }
                );
        }
    }
}
