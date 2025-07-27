using Feyamo.DAL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL.ApiRepositories
{
    public interface IGenericRepoAPI<T> where T : class 
    {
        //Task<T> GetAsync(int id);

       // Task<IEnumerable<T>> GetAllAsync();




        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<T> GetWithSpecAsync(ISpecification<T> spec);


    }
}
