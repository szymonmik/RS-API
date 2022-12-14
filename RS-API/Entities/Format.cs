using System.ComponentModel;

namespace RS_API.Entities;

public enum Format
{
	[Description("Single")]
	Single,
	[Description("Maxi")]
	Maxi,
	[Description("LP")]
	Lp,
	[Description("Other")]
	Other
}