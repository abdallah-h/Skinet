using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications {
    /// <summary>
    /// replace include functionallity to include ProductType and ProductBrand
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseSpecification<T> : ISpecification<T> {
        public BaseSpecification () { }

        public BaseSpecification (Expression<Func<T, bool>> criteria) {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
        new List<Expression<Func<T, object>>> ();

        /// <summary>
        /// add expression to includes list
        /// </summary>
        /// <param name="includeExpression"></param>
        protected void AddInclude (Expression<Func<T, object>> includeExpression) {
            Includes.Add (includeExpression);
        }
    }
}