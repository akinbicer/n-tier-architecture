using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract;

public interface IAccountService
{
    IDataResult<User> Login(LoginDto userForLoginDto);
    IDataResult<User> Register(RegisterDto userForRegisterDto, string password);
    IDataResult<AccessToken> CreateAccessToken(User user);
    IResult UserExists(string username);
}