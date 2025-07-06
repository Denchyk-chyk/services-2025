using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models;

[Table("fruits")]
public class Fruit
{
	[Required]
	[Column("fruit_id")]
	public int Id { get; set; }

	[Required]
	[StringLength(100)]
	[Column("fruit_name")]
	public string Name { get; set; }

	[Required]
	[Range(0.01, 1000)]
	[Column("fruit_price")]
	public decimal Price { get; set; }

	[StringLength(500)]
	[Column("fruit_description")]
	public string Description { get; set; }

	[Url]
	[Column("fruit_image_url")]
	public string ImageUrl { get; set; }
}
