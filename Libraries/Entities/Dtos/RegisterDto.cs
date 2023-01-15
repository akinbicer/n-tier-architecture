using Core.Entities;

namespace Entities.Dtos;

public class RegisterDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MailAddress { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}