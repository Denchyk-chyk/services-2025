namespace Lab7Api.Models;

public class BookDto
{
	public int? Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public string Genre { get; set; } = string.Empty;
	public string Publisher { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int Year { get; set; }
}
