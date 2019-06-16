﻿//using BookStore.Models;
//using BookStore.UnitOfWork;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BookStore.Repositories
//{
//    public class GenericRepository<T> : IGenericRepository<T> where T : class
//    {
//        private readonly BookStoreContext _context = null;
//        private DbSet<T> table = null;
//        public GenericRepository(IUnitOfWork unitOfWork): this(unitOfWork.Context)
     
//        public IEnumerable<T> GetAll()
//        {
//            return table.ToList();
//        }
//        public T GetById(object id)
//        {
//            return table.Find(id);
//        }
//        public void Insert(T obj)
//        {
//            table.Add(obj);
//        }
//        public void Update(T obj)
//        {
//            table.Attach(obj);
//            _context.Entry(obj).State = EntityState.Modified;
//        }
//        public void Delete(object id)
//        {
//            T existing = table.Find(id);
//            table.Remove(existing);
//        }
//        public void Save()
//        {
//            _context.SaveChanges();
//        }
//    }
//}
