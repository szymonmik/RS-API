namespace RS_API.Entities;

public class Order
{
	public int Id { get; set; }
	public ICollection<OrderRecord> OrderRecords { get; set; }
	public double TotalValue { get; set; }
	public Country Country { get; set; }
	public double TaxRate { get; set; }
	public double TaxAmount { get; set; }
	public double TotalAmount { get; set; }
	public OrderStatus OrderStatus { get; set; }
}