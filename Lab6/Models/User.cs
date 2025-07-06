using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models;

[Table("users")]
public class User
{
	[Required]
	[Column("user_id")]
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	[Column("user_name")]
	public string Name { get; set; }

	[Required]
	[Column("user_password_hash")]
	public byte[] PasswordHash { get; set; }

	[Required]
	[EmailAddress]
	[Column("user_email")]
	public string Email { get; set; }

	[Column("user_is_admin")]
	public bool IsAdmin { get; set; }
}
