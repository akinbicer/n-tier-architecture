using Core.Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    List<Role> GetRoles(User entity);
    User GetUserById(Guid id);
    User GetUserByUsername(string username);
    User GetUserByMailAddress(string mailAddress);
    bool Add(User entity);
}