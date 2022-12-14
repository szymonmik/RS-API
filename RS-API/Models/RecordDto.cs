namespace RS_API.Models;

public class RecordDto
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Artist { get; set; }
	public string Genre { get; set; }
	public string? Description { get; set; }
	public int ReleaseDate { get; set; }
	public string Format { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }
}