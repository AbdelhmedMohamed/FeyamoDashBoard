using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.DAL.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Critria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get ; set ; }
        public Expression<Func<T, object>> OrderByDesc { get ; set ; }

        public BaseSpecifications()
        {
            //Critria = null
        }

        public BaseSpecifications(Expression<Func<T, bool>> critriaExpression)
        {
            Critria = critriaExpression;
        }


        public void AddOrderBy(Expression<Func<T, object>> orderByExpression) //just setter for orderBy
        {
            OrderBy = orderByExpression;
        }


        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression) //just setter for orderByDesc
        {
            OrderByDesc = orderByDescExpression;
        }




    }
}
