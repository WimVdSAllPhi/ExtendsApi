using ExtendsApi.DataLayer.Repository.Interfaces;
using ExtendsApi.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ExtendsApi.DataLayer.Repository
{
    public class BaseRepository<TEntity, TIndex> : BaseViewRepository<TEntity>, IBaseRepository<TEntity, TIndex>
        where TIndex : struct
        where TEntity : MainBaseEntity<TIndex>
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

        public void AddRange(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
        }

        public void AddRange(IQueryable<TEntity> entities)
        {
            table.AddRange(entities);
        }

        public TEntity Edit(TEntity entity)
        {
            var newEntity = table.Update(entity).Entity;
            return newEntity;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
        }

        public void UpdateRange(IQueryable<TEntity> entities)
        {
            table.UpdateRange(entities);
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

        public void HardDeleteRange(IEnumerable<TEntity> entities)
        {
            table.RemoveRange(entities);
        }

        public void HardDeleteRange(IQueryable<TEntity> entities)
        {
            table.RemoveRange(entities);
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
