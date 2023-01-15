using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess;

public interface IBaseRepository<T> where T : class, IEntity, new()
{
    T Get(Expression<Func<T, bool>> filter);
    IList<T> GetList(Expression<Func<T, bool>>? filter = null);
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(T entity);
}