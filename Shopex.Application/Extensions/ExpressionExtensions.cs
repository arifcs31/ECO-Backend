using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Application.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TEntity,bool>> AndCondition<TEntity>(this Expression<Func<TEntity,bool>> source, Expression<Func<TEntity, bool>> newCondition)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(newCondition == null)    
                return source;
            var invocation = Expression.Invoke(newCondition, source.Parameters.Cast<Expression>());
            var expression = Expression.Lambda<Func<TEntity, bool>> (Expression.And(source.Body, invocation), source.Parameters);

            return expression.Expand();
        }
    }
}
