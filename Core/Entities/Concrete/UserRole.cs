using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete;

[Table("user_role", Schema = "public")]
public class UserRole : BaseEntity
{
    [Column("user_id")] public Guid UserId { get; set; }

    [Column("role_id")] public Guid RoleId { get; set; }

    [ForeignKey("UserId")] public virtual User? User { get; set; }

    [ForeignKey("RoleId")] public virtual Role? Role { get; set; }
}