using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories;

namespace BookStore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BookStoreContext _bookStoreContext;
        public IBookRepository BookRepository { get; set; }

        public UnitOfWork(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
            BookRepository = new BookRepository(_bookStoreContext);
        }

        public void Save()
        {
            _bookStoreContext.SaveChanges();   
        }
        public  Task<int> SaveAsync()
        {
            return  _bookStoreContext.SaveChangesAsync();
        }
        public void Dispose()
        {
             
            _bookStoreContext.Dispose();
        }
    }
}
