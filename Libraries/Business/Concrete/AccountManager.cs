using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete;

public class AccountManager : IAccountService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserService _userService;

    public AccountManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    [ValidationAspect(typeof(RegisterValidator), Priority = 1)]
    public IDataResult<User> Register(RegisterDto userForRegisterDto, string password)
    {
        HashingHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        User user = new()
        {
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            MailAddress = userForRegisterDto.MailAddress,
            Username = userForRegisterDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        _userService.Add(user);
        return new SuccessDataResult<User>(user, Messages.UserRegistered);
    }

    [ValidationAspect(typeof(LoginValidator), Priority = 1)]
    public IDataResult<User> Login(LoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetUserByUsername(userForLoginDto.Username);
        return userToCheck == null
            ? new ErrorDataResult<User>(Messages.UserNotFound)
            : !HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)
                ? new ErrorDataResult<User>(Messages.PasswordError)
                : new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
    }

    public IResult UserExists(string username)
    {
        return _userService.GetUserByUsername(username) != null ? new ErrorResult(Messages.UserAlreadyExists) : new SuccessResult();
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
        var claims = _userService.GetRoles(user);
        var accessToken = _tokenHelper.CreateToken(user, claims);

        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    }
}