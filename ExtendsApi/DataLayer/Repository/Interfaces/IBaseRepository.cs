using ExtendsApi.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExtendsApi.DataLayer.Repository.Interfaces
{
    public interface IBaseRepository<TEntity, TIndex> : IBaseViewRepository<TEntity>
        where TIndex : struct
        where TEntity : MainBaseEntity<TIndex>
    {
        TEntity GetById(TIndex id);

        TEntity Create(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void AddRange(IQueryable<TEntity> entities);
        TEntity Edit(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void UpdateRange(IQueryable<TEntity> entities);
        TEntity SoftDelete(TIndex id);
        TEntity SoftDelete(TEntity entity);
        TEntity HardDelete(TIndex id);
        TEntity HardDelete(TEntity entity);
        void HardDeleteRange(IEnumerable<TEntity> entities);
        void HardDeleteRange(IQueryable<TEntity> entities);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        int SaveChanges();
    }
}
