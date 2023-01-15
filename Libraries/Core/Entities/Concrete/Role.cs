using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete;

[Table("role", Schema = "public")]
public class Role : BaseEntity
{
    [Column("name")] public string? Name { get; set; }
}