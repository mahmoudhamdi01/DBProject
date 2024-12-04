using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepositories<T> where T : class
    {
        private readonly CompanyDbContext _dbContext;

        public GenericRepository(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int add(T item)
        {
            _dbContext.Add(item);
            return _dbContext.SaveChanges();
        }

        public int delete(T item)
        {
            _dbContext.Remove(item);
            return _dbContext.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }


        public T GetById(int Id)
         => _dbContext.Set<T>().Find(Id);

        public int update(T item)
        {
            _dbContext.Update(item);
            return _dbContext.SaveChanges();
        }
    }

  
}
