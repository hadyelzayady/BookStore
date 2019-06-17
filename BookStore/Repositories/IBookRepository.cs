using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        //getbestbook
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        void Insert(Book book);
        void Update(Book book);
        void LoadBookCategory(Book book);
        void Delete(int id);
    }
}
