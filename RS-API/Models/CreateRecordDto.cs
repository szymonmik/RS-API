using RS_API.Entities;

namespace RS_API.Models;

public class CreateRecordDto
{
	public string Title { get; set; }
	public string Artist { get; set; }
	public Genre Genre { get; set; }
	public string? Description { get; set; }
	public int ReleaseDate { get; set; }
	public Format Format { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }
}