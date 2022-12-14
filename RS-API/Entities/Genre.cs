using System.ComponentModel;

namespace RS_API.Entities;

public enum Genre
{
	[Description("Rock")]
	Rock,
	[Description("Progressive Rock")]
	ProgressiveRock,
	[Description("Metal")]
	Metal,
	[Description("Progressive Metal")]
	ProgressiveMetal,
	[Description("Classical")]
	Classical,
	[Description("Punk")]
	Punk,
	[Description("Pop Punk")]
	PopPunk,
	[Description("Thrash")]
	Thrash,
	[Description("Jazz")]
	Jazz
}