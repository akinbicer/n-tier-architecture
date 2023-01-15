using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public List<Role> GetRoles(User entity)
    {
        return _userDal.GetRoles(entity);
    }

    public User GetUserById(Guid id)
    {
        return _userDal.Get(x => x.Id == id);
    }

    public User GetUserByUsername(string username)
    {
        return _userDal.Get(x => x.Username == username);
    }

    public User GetUserByMailAddress(string mailAddress)
    {
        return _userDal.Get(x => x.MailAddress == mailAddress);
    }

    public bool Add(User entity)
    {
        return _userDal.Add(entity);
    }
}