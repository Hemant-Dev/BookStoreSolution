using BookStore.Models;
using BookStore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> MyCategories { get; set; }
        public DbSet<Product> MyProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Fantasy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Romantic", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Song of Ice and Fire", Author = "George R.R Martin", Description = "A Book of Game of Thrones Series", ISBN = "978-0553381689", ListPrice = 15.0, Price = 50.0, Price50 = 500.0, Price100 = 5000.0 }
                );
        }

    }
}
