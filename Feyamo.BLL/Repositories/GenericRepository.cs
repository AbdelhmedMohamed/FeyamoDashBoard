using Feyamo.BLL.Interfacies;
using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T item)
        {
           _dbContext.Add(item);

            //return _dbContext.SaveChanges();

        }

        public void Delete(T item)
        {
           _dbContext.Remove(item);
            //return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Hotel))
            {
                return (IEnumerable<T>) _dbContext.Hotels.Include(H=>H.Images).AsNoTracking().ToList();
            }
            else if (typeof(T) == typeof(Place))
            {
                return (IEnumerable<T>)_dbContext.Places.Include(H => H.Images).AsNoTracking().ToList();
            }
            else
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            };

        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            //return _dbContext.SaveChanges(); 
        }

    }
}
