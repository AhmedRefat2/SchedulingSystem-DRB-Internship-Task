using InternshipTask.Models;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Specifications;

namespace Talabat.Repository.GenericRepository
{
    internal static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> specs)
        {
            var query = inputQuery; // _dbContext.Set<TEntity>

            // 1. Criteria
            if(specs.Criteria is not null) // E => E.Id == 1
                query = query.Where(specs.Criteria);
            // query = _dbContext.Set<TEntity>().Where(criteria);

            // 2. Includes 
            if (specs.Includes is not null && specs.Includes.Count() > 0)
                query = specs.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            // 5. Pagination
            if (specs.IsPaginationEnabled)
                query = query.Skip(specs.Skip).Take(specs.Take);

            return query;
        }

    }
}
