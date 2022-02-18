using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokemonSkills;

namespace Tests
{
	[TestClass]
	public class TestCombatClass
	{
		[TestMethod]
		public void CombatTurn()
		{
			var arceus1 = new Arceus(100);
			arceus1.Nickname = "Arcy";
			arceus1.SetMoves(new SkillThunder(), null, null, null);

			var arceus2 = new Arceus(100);
			arceus2.SetMoves(new SkillThunder(), null, null, null);

			var fight = new CombatInstance(
				("Jean", arceus1, new List<Pokemon>(){}),
				("Charles", arceus2, new List<Pokemon>(){})
			);

			// Redirect console
			using var reader = new StreamReader("..\\..\\..\\Tests\\test1_in.txt");
			using var writer = new StreamWriter("..\\..\\..\\Tests\\test1_out.txt");
			Console.SetIn(reader);
			Console.SetOut(writer);

			fight.DoTurn();
			
		}
	}
}