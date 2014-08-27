using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericServices.Core;

namespace GenericServices.ServicesAsync
{

    public interface IDetailServiceAsync<TData>
        where TData : class
    {
        /// <summary>
        /// This gets a single entry using the lambda expression as a where part
        /// </summary>
        /// <param name="whereExpression">Should be a 'where' expression that returns one item</param>
        /// <returns>Task with Status. If valid Result is data as read from database (not tracked), otherwise null</returns>
        Task<ISuccessOrErrors<TData>> GetDetailUsingWhereAsync(Expression<Func<TData, bool>> whereExpression);

        /// <summary>
        /// This finds an entry using the primary key(s) in the data
        /// </summary>
        /// <param name="keys">The keys must be given in the same order as entity framework has them</param>
        /// <returns>Task with Status. If valid Result is data as read from database (not tracked), otherwise null</returns>
        Task<ISuccessOrErrors<TData>> GetDetailAsync(params object[] keys);
    }

    public interface IDetailServiceAsync<TData, TDto>
        where TData : class
        where TDto : EfGenericDtoAsync<TData, TDto>, new()
    {
        /// <summary>
        /// This gets a single entry using the lambda expression as a where part
        /// </summary>
        /// <param name="whereExpression">Should be a 'where' expression that returns one item</param>
        /// <returns>Task with Status. If valid Result is data as read from database (not tracked), otherwise null</returns>
        Task<ISuccessOrErrors<TDto>> GetDetailUsingWhereAsync(Expression<Func<TData, bool>> whereExpression);


        /// <summary>
        /// This finds an entry using the primary key(s) in the data
        /// </summary>
        /// <param name="keys">The keys must be given in the same order as entity framework has them</param>
        /// <returns>Task with Status. If valid Result is data as read from database (not tracked), otherwise null</returns>
        Task<ISuccessOrErrors<TDto>> GetDetailAsync(params object[] keys);

    }
}