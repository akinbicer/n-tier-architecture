using Core.Entities;

namespace Entities.Dtos;

public class UserDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? MailAddress { get; set; }
}