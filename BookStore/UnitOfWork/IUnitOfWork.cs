using BookStore.Models;
using BookStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IBookRepository BookRepository { get; }
        //IGenericRepository<Post> PostRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
