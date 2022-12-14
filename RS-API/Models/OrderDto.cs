namespace RS_API.Models;

public class OrderDto
{
	public int Id { get; set; }
	public ICollection<RecordDto> OrderRecords { get; set; }
	public double TotalValue { get; set; }
	public string Country { get; set; }
	public double TaxRate { get; set; }
	public double TaxAmount { get; set; }
	public double TotalAmount { get; set; }
	public string OrderStatus { get; set; }
}