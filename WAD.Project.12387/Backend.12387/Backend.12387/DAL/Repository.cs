using Backend._12387.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend._12387.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly FootballContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(FootballContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] foreignKeyProperties)
        {
            if (foreignKeyProperties != null)
            {

                var query = _dbSet.AsQueryable();

            foreach (var foreignKeyProperty in foreignKeyProperties)
            {
                query = query.Include(foreignKeyProperty);
            }

            return await query.ToListAsync();
            } else
            {
                return await _dbSet.ToListAsync();
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);   
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await GetByIdAsync(GetEntityId(entity));
            if(existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
                _context.Entry(entity).State = EntityState.Modified;
            } else
            {
                throw new InvalidOperationException("Entity does not exist");
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) { 
                _dbSet.Remove(entity);
            } else
            {
                throw new InvalidOperationException("Entity does not exist");
            }
        }

        private async Task UpdateAssociatedEntitiesAsync(TEntity entity)
        {
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                {
                    var collection = (ICollection<object>)property.GetValue(entity);
                    if (collection != null && collection.Any())
                    {
                        foreach (var associatedEntity in collection)
                        {
                            var foreignKeyProperties = associatedEntity.GetType().GetProperties().Where(p => p.Name == entityType.Name + "Id");
                            foreach (var foreignKeyProperty in foreignKeyProperties)
                            {
                                foreignKeyProperty.SetValue(associatedEntity, null);
                            }
                            await UpdateAssociatedEntitiesAsync(associatedEntity as TEntity);
                        }
                    }
                }
            }
        }

        protected virtual int GetEntityId(TEntity entity)
         {
            var entityName = typeof(TEntity).Name;
            var idProp = entity.GetType().GetProperty($"{entityName}Id");
        
            if(idProp == null)
            {
                throw new InvalidOperationException($"Entity {entityName} does not not have a valid Id name");
        }
        
            return (int)idProp.GetValue(entity);
         }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        } 
    }
}
