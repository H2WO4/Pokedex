namespace Pokedex.Utils;

public static class EnumExtension
{
	/// <summary>
	/// Return all flags from a flag enum value
	/// </summary>
	/// <param name="input">The value the get the flags from</param>
	/// <returns>An enumerable containing all found flags</returns>
	public static IEnumerable<T> GetFlags<T>(this T input)
		where T : Enum
	{
		foreach (T flag in Enum.GetValues(input.GetType()))
			if (input.HasFlag(flag))
				yield return flag;
	}
}