using ExtendsApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExtendsApi.DataLayer.Interfaces
{
    public interface IBaseViewRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="GetAllByPagination(int, int)"/>
        /// </summary>
        /// <returns>List of ALL elements in the table</returns>
        IQueryable<TEntity> GetAll();

        PagedResult<TEntity> GetAllByPagination(int page, int pageSize);

        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="FilterByPagination(Func&lt;TEntity, bool&gt;, int, int)"/>
        /// </summary>
        /// <returns>List of ALL elements in the table</returns>
        IQueryable<TEntity> Filter(Func<TEntity, bool> predicate);
        IQueryable<TEntity> FilterOrder(Func<TEntity, bool> predicate, OrderExtention orderExtention);

        PagedResult<TEntity> FilterByPagination(Func<TEntity, bool> predicate, int page, int pageSize);
        PagedResult<TEntity> FilterOrderByPagination(Func<TEntity, bool> predicate, OrderExtention orderExtention, int page, int pageSize);

        TEntity GetByOne(Func<TEntity, bool> predicate);
        TEntity GetByOneAndIncludes(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="FindByIncludeByPagination(int, int, Func&lt;TEntity, bool&gt;, Expression&lt;Func&lt;TEntity, object&gt;&gt;[])" />
        /// </summary>
        /// <returns>List of ALL elements in the table with the specifique includes</returns>
        IQueryable<TEntity> FindByInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> FindOrderByInclude(Func<TEntity, bool> predicate, OrderExtention orderExtention, params Expression<Func<TEntity, object>>[] includes);

        PagedResult<TEntity> FindByIncludeByPagination(int page, int pageSize, Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes);

        PagedResult<TEntity> FindByIncludeOrderByPagination(int page, int pageSize, Func<TEntity, bool> predicate, OrderExtention orderExtention, params Expression<Func<TEntity, object>>[] includes);

    }
}
