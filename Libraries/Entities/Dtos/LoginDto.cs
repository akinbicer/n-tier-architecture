using Core.Entities;

namespace Entities.Dtos;

public class LoginDto : BaseDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}