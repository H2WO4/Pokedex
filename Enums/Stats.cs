namespace Pokedex.Enums
{
	[Flags]
	public enum Stats
	{
		Atk = 1 << 0,
		Def = 1 << 1,
		SpAtk = 1 << 2,
		SpDef = 1 << 3,
		Spd = 1 << 4,
	}
}