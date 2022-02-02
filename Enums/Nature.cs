namespace Pokedex.Enums
{
	public enum Nature
	{
		# region Stat Flags
		None = 0,
		
		// Stat Bonuses
		PlusHP = 1,
		PlusAtk = 2,
		PlusDef = 4,
		PlusSpAtk = 8,
		PlusSpDef = 16,
		PlusSpd = 32,

		// Stat Minuses
		MinusHP = 64,
		MinusAtk = 128,
		MinusDef = 256,
		MinusSpAtk = 512,
		MinusSpDef = 1024,
		MinusSpd = 2048,
		# endregion

		// Neutral
		Hardy = None,
		Docile = None,
		Bashful = None,
		Quirky = None,
		Serious = None,

		// Atk+
		Lonely = PlusAtk | MinusDef,
		Adamant = PlusAtk | MinusSpAtk,
		Naughty = PlusAtk | MinusSpDef,
		Brave = PlusAtk | MinusSpd,

		// Def+
		Bold = PlusDef | MinusAtk,
		Impish = PlusDef | MinusSpAtk,
		Lax = PlusDef | MinusSpDef,
		Relaxed = PlusDef | MinusSpd,

		// SpAtk+
		Modest = PlusSpAtk | MinusAtk,
		Mild = PlusSpAtk | MinusDef,
		Rash = PlusSpAtk | MinusSpDef,
		Quiet = PlusSpAtk | MinusSpd,

		// SpDef+
		Calm = PlusSpDef | MinusAtk,
		Gentle = PlusSpDef | MinusDef,
		Careful = PlusSpDef | MinusSpAtk,
		Sassy = PlusSpDef | MinusSpd,

		// Spd+
		Timid = PlusSpd | MinusAtk,
		Hasty = PlusSpd | MinusDef,
		Jolly = PlusSpd | MinusSpAtk,
		Naive = PlusSpd | MinusSpDef,
	}
}