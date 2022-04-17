using System.Runtime.Intrinsics.X86;


namespace Pokedex.Utils;

public static class EnumExtension
{
	/// <summary>
	///     Check whenever a given enum value contains a certain flag
	/// </summary>
	/// <param name="input">The enum value to check in</param>
	/// <param name="flag">The flag to check for</param>
	/// <typeparam name="T">An int-based Enum</typeparam>
	public static unsafe bool HasFlagUnsafe<T>(this T input, T flag)
		where T : unmanaged, Enum
	{
		uint inputInt = *(uint*)&input,
			 flagInt  = *(uint*)&flag;

		return (inputInt & flagInt) == flagInt;
	}

	/// <summary>
	///     Determines whether a given int-based Enum value is a flag
	/// </summary>
	/// <remarks>
	///     Might produce undefined behavior if T is not a flag-Enum.
	/// </remarks>
	/// <param name="input">The value to check</param>
	public static unsafe bool IsFlag<T>(this T input)
		where T : unmanaged, Enum
	{
		uint inputInt = *(uint*)&input;

		return Popcnt.PopCount(inputInt) == 1;
	}

	/// <summary>
	///     Convert an int value to its equivalent Enum value
	/// </summary>
	/// <param name="value">The value to convert</param>
	/// <typeparam name="T">The int-based Enum to convert it to</typeparam>
	public static unsafe T AsEnum<T>(this int value)
		where T : unmanaged, Enum
	{
		return *(T*)&value;
	}

	/// <summary>
	///     Return all single-flag values of a flag-Enum
	/// </summary>
	/// <remarks>
	///     Might produce undefined behavior if T is not a flag-Enum.
	/// </remarks>
	/// <typeparam name="T">The Enum to look in</typeparam>
	/// <returns></returns>
	public static IEnumerable<T> GetAllFlags<T>()
		where T : unmanaged, Enum
	{
		var i = 1;
		while (true)
		{
			if (Enum.IsDefined(typeof(T), i) is false)
				yield break;

			yield return i.AsEnum<T>();

			i *= 2;
		}
	}

	/// <summary>
	///     Return all flags from a flag enum value
	/// </summary>
	/// <param name="input">The value the get the flags from</param>
	/// <returns>An enumerable containing all found flags</returns>
	public static IEnumerable<T> GetFlags<T>(this T input)
		where T : unmanaged, Enum
	{
		foreach (T flag in GetAllFlags<T>())
		{
			if (input.HasFlagUnsafe(flag))
				yield return flag;
		}
	}
}