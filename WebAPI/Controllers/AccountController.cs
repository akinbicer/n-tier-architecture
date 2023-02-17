using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Login")]
    public ActionResult Login(LoginDto loginDto)
    {
        var userToLogin = _accountService.Login(loginDto);
        if (!userToLogin.Success) return BadRequest(userToLogin.Message);

        var result = _accountService.CreateAccessToken(userToLogin.Data);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("Register")]
    public ActionResult Register(RegisterDto registerDto)
    {
        var userExists = _accountService.UserExists(registerDto.Username);
        if (!userExists.Success) return BadRequest(userExists.Message);

        var registerResult = _accountService.Register(registerDto, registerDto.Password);
        var result = _accountService.CreateAccessToken(registerResult.Data);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}