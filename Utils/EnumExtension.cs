namespace Pokedex.Utils;

public static class EnumExtension
{
	public static unsafe bool HasFlag2<T>(this T input, T value)
		where T : unmanaged, Enum
	{
		return (*(int*)&input & *(int*)&value) != 0;
	}
	
	/// <summary>
	/// Return all flags from a flag enum value
	/// </summary>
	/// <param name="input">The value the get the flags from</param>
	/// <returns>An enumerable containing all found flags</returns>
	public static unsafe IEnumerable<T> GetFlags<T>(this T input)
		where T : unmanaged, Enum 
		=> Enum.GetValues(input.GetType())
			   .Cast<T>()
			   .Where(value => System.Runtime.Intrinsics.X86.Popcnt.X64.PopCount(*(ulong*)&value) == 1)
			   .Where(flag => input.HasFlag2(flag));
}