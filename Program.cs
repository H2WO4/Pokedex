using System.Text;

using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Models.PokemonMoves;
using Pokedex.Models.Pokemons;
using Pokedex.Models.Weathers;


namespace Pokedex;

public static class Program
{
	public static readonly Random Rnd = new(0);

	public static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;
		PokeType.InitializeTypes();

		var raichu = new Pokemon(Raichu.Singleton, 100, "Pikachu");
		raichu.SetMoves(new MoveThunder(), new MoveSwordsDance(), null, null);
		raichu.SetIVs(31, 31, 31,
					  31, 31, 31);
		raichu.CurrHP = 999;

		var blastoise = new Pokemon(Blastoise.Singleton, 100, "Squid Game");
		blastoise.SetMoves(new MoveExtremeSpeed(), new MoveUTurn(), null, null);
		blastoise.SetIVs(31, 31, 31,
						 31, 31, 31);
		blastoise.CurrHP = 999;

		var charizard = new Pokemon(Charizard.Singleton, 100, "Over-hyped");
		charizard.SetMoves(new MoveExtremeSpeed(), null, null, null);
		charizard.SetIVs(31, 31, 31,
						 31, 31, 31);
		charizard.CurrHP = 999;

		var arceus = new Pokemon(Arceus.Singleton, 100, "Mother Fucking God");
		arceus.SetMoves(new MoveGuillotine(), null, null, null);
		arceus.SetIVs(31, 31, 31,
					  31, 31, 31);
		arceus.CurrHP = 999;

		var fight =
			new Combat(("Jean", new I_Battler[] { raichu }),
					   ("Charles", new I_Battler[] { blastoise, charizard, arceus }))
			{
				Weather = WeatherRain.Singleton,
			};

		// Redirect console
		using var reader = new StreamReader("../../../Tests/test1_in.txt");
		// var writer = new StringWriter();
		// using var writer = new StreamWriter("../../../Tests/test1_out.ans");
		Console.SetIn(reader);
		// Console.SetOut(writer);

		fight.DoCombat();
	}
}