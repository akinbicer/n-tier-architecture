using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity> where TEntity : BaseEntity, IEntity, new() where TContext : DbContext, new()
{
    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using TContext context = new();
        return context.Set<TEntity>().SingleOrDefault(filter);
    }

    public IList<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
    {
        using TContext context = new();
        return filter == null ? context.Set<TEntity>().AsNoTracking().ToList() : context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
    }

    public bool Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        entity.UpdatedDate = DateTime.Now;
        entity.DeletedDate = DateTime.Now;
        entity.IsUpdated = false;
        entity.IsDeleted = false;

        using TContext context = new();
        var addedEntity = context.Entry(entity);
        addedEntity.State = EntityState.Added;
        return context.SaveChanges() > 0;
    }

    public bool Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        entity.IsUpdated = true;

        using TContext context = new();
        var updatedEntity = context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        return context.SaveChanges() > 0;
    }

    public bool Delete(TEntity entity)
    {
        entity.DeletedDate = DateTime.Now;
        entity.IsDeleted = true;

        return Update(entity);

        //using TContext context = new();
        //EntityEntry<TEntity> deletedEntity = context.Entry(entity);
        //deletedEntity.State = EntityState.Deleted;
        //return context.SaveChanges() > 0;
    }
}