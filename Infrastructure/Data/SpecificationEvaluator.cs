using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    /// <summary>
    /// specification evaluater that takes a list of queries and expressions
    /// to evalute them and generates iqueryable
    /// this class act as Include in ProductRepository class 
    /// ex. Include (p => p.ProductBrand) and Include (p => p.ProductType)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec) {
            var query = inputQuery;

            if (spec.Criteria != null) {
                // ex. of spec.Criteria is (p => p.ProductTypeId == id)
                query = query.Where (spec.Criteria);
            }

            if (spec.OrderBy != null) {
                query = query.OrderBy (spec.OrderBy);
            }

            if (spec.OrderByDesc != null) {
                query = query.OrderByDescending (spec.OrderByDesc);
            }

            if (spec.IsPagingEnable) {
                query = query.Skip (spec.Skip).Take (spec.Take);
            }

            // aggregate our include expressions and return it
            query = spec.Includes.Aggregate (query, (current, include) => current.Include (include));
            return query;
        }
    }
}