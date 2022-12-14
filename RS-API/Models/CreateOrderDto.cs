using RS_API.Entities;

namespace RS_API.Models;

public class CreateOrderDto
{
	public ICollection<OrderRecordDto> OrderRecords { get; set; }
	public Country Country { get; set; }
}