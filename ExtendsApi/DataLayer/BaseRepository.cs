using ExtendsApi.DataLayer.Interfaces;
using ExtendsApi.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtendsApi.DataLayer
{
    public class BaseRepository<TEntity, TIndex> : BaseViewRepository<TEntity>, IBaseRepository<TEntity, TIndex>
        where TIndex : struct
        where TEntity : class, IMainBaseEntity<TIndex>
    {

        public BaseRepository(DbContext context) : base(context)
        {

        }

        public TEntity GetById(TIndex id)
        {
            return table.Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            var newEntity = table.Add(entity).Entity;
            return newEntity;
        }

        public TEntity Edit(TEntity entity)
        {
            var newEntity = table.Update(entity).Entity;
            return newEntity;
        }

        public TEntity SoftDelete(TIndex id)
        {
            var entityToDelete = table.Find(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
                entityToDelete = table.Update(entityToDelete).Entity;
            }
            return entityToDelete;
        }

        public TEntity SoftDelete(TEntity entity)
        {
            var entityToDelete = table.Find(entity.Id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
                entityToDelete = table.Update(entityToDelete).Entity;
            }
            return entityToDelete;
        }

        public TEntity HardDelete(TIndex id)
        {
            var entityToDelete = table.Find(id);
            if (entityToDelete != null)
            {
                entityToDelete = table.Remove(entityToDelete).Entity;
            }
            return entityToDelete;
        }

        public TEntity HardDelete(TEntity entity)
        {
            return table.Remove(entity).Entity;
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
