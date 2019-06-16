using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.UnitOfWork;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        //private readonly Book
        public BookRepository(BookStoreContext context)
        {   

        }
        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
            //return table.ToList();
        }
        public Book GetById(int id)
        {
            //return table.Find(id);
            throw new NotImplementedException();

        }
        public void Insert(Book book)
        {
            //table.Add(book);
        }
        public void Update(Book book)
        {
            //table.Attach(book);
            //_context.Entry(book).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            //Book existing = table.Find(id);
            //table.Remove(existing);
        }
 
       
    }
}
