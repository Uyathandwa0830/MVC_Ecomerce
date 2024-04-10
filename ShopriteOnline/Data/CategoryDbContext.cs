using Microsoft.EntityFrameworkCore;
using ShopriteOnline.Models;

namespace ShopriteOnline.Data
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext>options):
            base(options)
        {
         
        }
        //DbSet means Table name Categories
        public DbSet<Category> categories { get; set; }
        //Add the Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Food", DisplayOrder = 2 },
               new Category { Id = 3, Name = "History", DisplayOrder = 3 });
        }


    }
}
