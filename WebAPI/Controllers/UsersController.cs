using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUsers")]
    [Authorize(Roles = "Admin")]
    public ActionResult GetUsers(string username)
    {
        var user = _userService.GetUserByUsername(username);
        return Ok(user);
    }
}