using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace BookStore.Models
{
    public class BookStoreContext:DbContext
    {
        private IConfiguration configuration;

        public BookStoreContext(IConfiguration configuration)  { this.configuration = configuration; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(configuration.GetValue<string>("DBConnectionString")  );
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
