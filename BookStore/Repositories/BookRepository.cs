using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        //private readonly Book
        protected readonly BookStoreContext Context;

        public BookRepository(BookStoreContext context)
        {
            Context = context;
        }
        public Task<List<Book>> GetAll()
        {
            return Context.Books.Include(b=>b.Category.ParentCategory).Include(b=>b.Category.SubCategory).ToListAsync();
        }
        public Task<Book> GetById(int id)
        {
            return Context.Books.Include(b => b.Category.ParentCategory).Include(b => b.Category.SubCategory).SingleOrDefaultAsync(i => i.Id == id);
        }
        public void Insert(Book book)
        {
            Context.Books.Add(book);
        }
        public void Update(Book book)
        {
            //_context.Entry(book).State = EntityState.Modified;
            Context.Books.Update(book);
        }
        public void LoadBookCategory(Book book)
        {
            Context.Entry(book).Reference(b => b.Category).Load();
            Context.Entry(book.Category).Reference(c => c.SubCategory).Load();
            Context.Entry(book.Category).Reference(c => c.ParentCategory).Load();
        }
        public void Delete(int id)
        {
            Book existing = Context.Books.Find(id);
            Context.Books.Remove(existing);
        }
 
       
    }
}
