using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Specifications
{
    public interface ISpecification<T> where T : class
    {
        public Expression<Func<T,bool>> Critria { get; set; }


        public List<Expression<Func<T,object>>> Includes { get; set; }

        public Expression<Func<T,object>> OrderBy { get; set; } //OrderBy(h => h.Name) Asc

        public Expression<Func<T, object>> OrderByDesc { get; set; } //OrderByDesc(h => h.Name) Desc Asc


    }
}
