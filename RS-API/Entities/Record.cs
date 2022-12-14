namespace RS_API.Entities;

public class Record
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Artist { get; set; }
	public Genre Genre { get; set; }
	public string? Description { get; set; }
	public int ReleaseDate { get; set; }
	public Format Format { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }
}