using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfBaseRepository<User, BackendContext>, IUserDal
{
    public List<Role> GetRoles(User user)
    {
        using BackendContext context = new();
        var result = from roles in context.Role
            join userRoles in context.UserRole
                on roles.Id equals userRoles.RoleId
            where userRoles.UserId == user.Id
            select new Role { Id = roles.Id, Name = roles.Name };
        return result.ToList();
    }
}