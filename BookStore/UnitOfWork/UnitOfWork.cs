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
        private readonly BookStoreContext _bookStoreContext;
        private IBookRepository _bookRepository;

        public UnitOfWork(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public IBookRepository BookRepository => _bookRepository = _bookRepository ?? new BookRepository(_bookStoreContext);

        public void Save()
        {
            _bookStoreContext.SaveChanges();
        }
    }
}
