namespace RS_API.Entities;

public class OrderRecord
{
	public int OrderId { get; set; }
	public Order Order { get; set; }
	public int RecordId { get; set; }
	public Record Record { get; set; }
	
	public int Quantity { get; set; }
}