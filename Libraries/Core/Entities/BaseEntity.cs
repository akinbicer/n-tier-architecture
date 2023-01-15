using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class BaseEntity : IEntity
{
    [Key] [Column("id")] public Guid Id { get; set; }

    [Column("created_date")] public DateTime CreatedDate { get; set; }

    [Column("created_user_id")] public Guid? CreatedUserId { get; set; }

    [Column("is_updated")] public bool IsUpdated { get; set; }

    [Column("updated_date")] public DateTime UpdatedDate { get; set; }

    [Column("updated_user_id")] public Guid? UpdatedUserId { get; set; }

    [Column("is_deleted")] public bool IsDeleted { get; set; }

    [Column("deleted_date")] public DateTime DeletedDate { get; set; }

    [Column("deleted_user_id")] public Guid? DeletedUserId { get; set; }
}