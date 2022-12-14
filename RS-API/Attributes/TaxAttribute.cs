namespace RS_API.Attributes;

public class TaxAttribute : Attribute
{
	public double Tax { get; set; }

	public TaxAttribute(double tax)
	{
		Tax = tax;
	}
}