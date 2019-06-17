using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookStoreContext:DbContext
    {

        public BookStoreContext()  { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=BookStore;Username=postgres;Password=12345");
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryParent> CategoriesParents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryParent>()
                .HasAlternateKey(p => new { p.CategoryId, p.ParentCategoryId });

            modelBuilder.Entity<Category>().HasMany(m => m.parents)
                    .WithOne(m => m.ParentCategory)
                    .OnDelete(DeleteBehavior.Cascade);
            //subcategoried of each category
            modelBuilder.Entity<Category>().HasMany(m => m.subCategories)
        .WithOne(m => m.SubCategory)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
