using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using Feyamo.DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.ApiRepositories
{
    public class GenericRepoAPI<T> : IGenericRepoAPI<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepoAPI(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }



        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    if (typeof(T) == typeof(Hotel))
        //    {
        //        return (IEnumerable<T>)await _dbContext.Set<Hotel>().Include(I => I.Images).Include(R=>R.reservationHotels).AsNoTracking().ToListAsync(); 
        //    }

        //    return await _dbContext.Set<T>().ToListAsync();
        //}

       

        //public async Task<T> GetAsync(int id)
        //{
        //    if (typeof(T) == typeof(Hotel))
        //    {
        //        return await _dbContext.Set<Hotel>().Where(H=>H.Id == id).Include(I => I.Images).Include(R => R.reservationHotels).FirstOrDefaultAsync() as T;

        //    }
        //    return await _dbContext.Set<T>().FindAsync(id);

        //}
      



        //=================================

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec).ToListAsync();
        }

        public async Task<T> GetWithSpecAsync(ISpecification<T> spec)
        {
           return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>() , spec).FirstOrDefaultAsync();   
        }



    }
}
