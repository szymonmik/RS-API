using System.ComponentModel;
using RS_API.Attributes;

namespace RS_API.Entities;

public enum Country
{
	[Description("Poland")]
	[Tax(0.23)]
	Poland,
	[Description("Germany")]
	[Tax(0.19)]
	Germany,
	[Description("UK")]
	[Tax(0.20)]
	Uk,
	[Description("Ukraine")]
	[Tax(0.20)]
	Ukraine,
	[Description("Netherlands")]
	[Tax(0.21)]
	Netherlands,
	[Description("Belgium")]
	[Tax(0.21)]
	Belgium,
	[Description("Italy")]
	[Tax(0.22)]
	Italy
}