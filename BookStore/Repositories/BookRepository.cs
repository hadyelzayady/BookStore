using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.UnitOfWork;

namespace BookStore.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        //private readonly Book
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IEnumerable<Book> GetAll()
        {
            return table.ToList();
        }
        public Book GetById(Book id)
        {
            return table.Find(id);
        }
        public void Insert(Book book)
        {
            table.Add(book);
        }
        public void Update(book)
        {
            table.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Delete(Book id)
        {
            Book existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
