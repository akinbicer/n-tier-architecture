using Core.Entities;

namespace Entities.Dtos;

public class RoleDto : BaseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}