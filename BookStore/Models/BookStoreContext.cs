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
    }
}
