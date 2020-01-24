using ExtendsApi.DataLayer.Models;

namespace ExtendsApi.DataLayer.Interfaces
{
    public interface IBaseRepository<TEntity, TIndex> : IBaseViewRepository<TEntity> 
        where TIndex : struct
        where TEntity : class, IMainBaseEntity<TIndex>
    {
        TEntity GetById(TIndex id);

        TEntity Create(TEntity entity);
        TEntity Edit(TEntity entity);
        TEntity SoftDelete(TIndex id);
        TEntity SoftDelete(TEntity entity);
        TEntity HardDelete(TIndex id);
        TEntity HardDelete(TEntity entity);

        //separate method SaveChanges can be helpful when using this pattern with UnitOfWork
        int SaveChanges();
    }
}
