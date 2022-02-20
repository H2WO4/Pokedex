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

			var pika = new Pikachu(100, "Pika");
			pika.SetMoves(new MoveThunder(), null, null, null);
			pika.SetIVs(0, 0, 0, 0, 0, 0);
			pika.CurrHP = 999;

			var squirtle = new Squirtle(100, "Squid Game");
			squirtle.SetMoves(new MoveExtremeSpeed(), null, null, null);
			squirtle.SetIVs(0, 0, 0, 0, 0, 0);
			squirtle.CurrHP = 999;

			var fight = new CombatInstance(
				("Jean", new List<Pokemon>(){ pika }),
				("Charles", new List<Pokemon>(){ squirtle })
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