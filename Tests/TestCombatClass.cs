using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex;
using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokemonMoves;

namespace Tests
{
	[TestClass]
	public class TestCombatClass
	{
		[TestMethod]
		public void CombatTurn()
		{
			Program.InitializeTypes();

			var raichu = new Raichu(100, "Pikachu");
			raichu.SetMoves(new MoveThunder(), null, null, null);
			raichu.SetIVs(31, 31, 31, 31, 31, 31);
			raichu.CurrHP = 999;

			var blastoise = new Blastoise(100, "Squid Game");
			blastoise.SetMoves(new MoveExtremeSpeed(), new MoveUTurn(), null, null);
			blastoise.SetIVs(31, 31, 31, 31, 31, 31);
			blastoise.CurrHP = 999;

			var charizard = new Charizard(100, "Overhyped");
			charizard.SetMoves(new MoveExtremeSpeed(), null, null, null);
			charizard.SetIVs(31, 31, 31, 31, 31, 31);
			charizard.CurrHP = 999;

			var arceus = new Arceus(100, "Mother Fucking God");
			arceus.SetMoves(new MoveGuillotine(), null, null, null);
			arceus.SetIVs(31, 31, 31, 31, 31, 31);
			arceus.CurrHP = 999;

			var fight = new CombatInstance(
				("Jean", new List<Pokemon>(){ raichu }),
				("Charles", new List<Pokemon>(){ blastoise, charizard, arceus })
			);

			// Redirect console
			using var reader = new StreamReader("..\\..\\..\\Tests\\test1_in.txt");
			// var writer = new StringWriter();
			using var writer = new StreamWriter("..\\..\\..\\Tests\\test1_out.txt");
			Console.SetIn(reader);
			Console.SetOut(writer);

			fight.DoTurn();
		}
	}
}