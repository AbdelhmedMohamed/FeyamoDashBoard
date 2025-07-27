using Feyamo.DAL.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feyamo.BLL
{
    public static class SpecificationEvaluator<TEntity>  where TEntity : class
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> innerQuery ,ISpecification<TEntity> spec )
        {
            var query = innerQuery;


            if (spec.Critria is not null) //  where
            {
                query = query.Where(spec.Critria);
                
            }

            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy); 
            }
            else if (spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }




            //include
            query = spec.Includes.Aggregate(query, (currentQuery, includesExpression) => currentQuery.Include(includesExpression));
           
            
            
            return query;


        }



    }
}
