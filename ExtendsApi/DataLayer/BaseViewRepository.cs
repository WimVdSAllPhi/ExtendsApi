using ExtendsApi.DataLayer.Interfaces;
using ExtendsApi.Methods;
using ExtendsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExtendsApi.DataLayer
{
    public class BaseViewRepository<TEntity> : IBaseViewRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> table;

        public BaseViewRepository(DbContext context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }

        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="GetAllByPagination(int, int)"/>
        /// </summary>
        /// <returns>List of ALL elements in the table</returns>
        public IQueryable<TEntity> GetAll()
        {
            return table.AsNoTracking();
        }

        public PagedResult<TEntity> GetAllByPagination(int page, int pageSize)
        {
            return table.AsNoTracking().GetPaged(page, pageSize);
        }

        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="FilterByPagination(Func&lt;TEntity, bool&gt;, int, int)" />
        /// </summary>
        /// <returns>List of ALL elements in the table</returns>
        public IQueryable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            return table.Where(predicate).AsQueryable();
        }

        public PagedResult<TEntity> FilterByPagination(Func<TEntity, bool> predicate, int page, int pageSize)
        {
            return table.Where(predicate).GetPaged(page, pageSize);
        }

        public TEntity GetByOne(Func<TEntity, bool> predicate)
        {
            return table.FirstOrDefault(predicate);
        }

        public TEntity GetByOneAndIncludes(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return table.IncludeMultiple(includes).FirstOrDefault(predicate);
        }

        /// <summary>
        /// Never use this function want if db table to big it slow down everything
        /// Instead use <see cref="FindByIncludeByPagination(int, int, Func&lt;TEntity, bool&gt;, Expression&lt;Func&lt;TEntity, object&gt;&gt;[])" />
        /// </summary>
        /// <returns>List of ALL elements in the table with the specifique includes</returns>
        public IQueryable<TEntity> FindByInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return table.IncludeMultiple(includes).Where(predicate).AsQueryable();
        }

        public PagedResult<TEntity> FindByIncludeByPagination(int page, int pageSize, Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return table.IncludeMultiple(includes).Where(predicate).GetPaged(page, pageSize);
        }
    }
}
