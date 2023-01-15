using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete;

[Table("user", Schema = "public")]
public class User : BaseEntity
{
    [Column("first_name")] public string? FirstName { get; set; }

    [Column("last_name")] public string? LastName { get; set; }

    [Column("username")] public string? Username { get; set; }

    [Column("mail_address")] public string? MailAddress { get; set; }

    [Column("password_salt")] public byte[]? PasswordSalt { get; set; }

    [Column("password_hash")] public byte[]? PasswordHash { get; set; }
}