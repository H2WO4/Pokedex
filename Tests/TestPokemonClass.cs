using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Models.Pokemons;

namespace Tests
{
	[TestClass]
	public class TestPokemonClass
	{
		[TestMethod]
		public void PokemonName()
		{
			var arceus = new Arceus(100);

			Assert.AreEqual(arceus.Name, "Arceus", $"Name should be 'Arceus', is {arceus.Name}");
		}

		[TestMethod]
		public void PokemonStats()
		{
			var arceus = new Arceus(100);
			arceus.setIVs(0, 0, 0, 0, 0, 0);
			arceus.setEVs(0, 0, 0, 0, 0, 0);

			Assert.AreEqual(arceus.HP, 350, $"HP stat should be 350, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk, 245, $"Atk stat should be 245, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def, 245, $"Def stat should be 245, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk, 245, $"SpAtk stat should be 245, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef, 245, $"SpDef stat should be 245, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd, 245, $"Spd stat should be 245, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonIVs()
		{
			var arceus = new Arceus(100);
			arceus.setIVs(31, 31, 31, 31, 31, 31);
			arceus.setEVs(0, 0, 0, 0, 0, 0);

			Assert.AreEqual(arceus.HP, 381, $"HP stat should be 381, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk, 276, $"Atk stat should be 276, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def, 276, $"Def stat should be 276, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk, 276, $"SpAtk stat should be 276, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef, 276, $"SpDef stat should be 276, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd, 276, $"Spd stat should be 276, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonEVs()
		{
			var arceus = new Arceus(100);
			arceus.setIVs(0, 0, 0, 0, 0, 0);
			arceus.setEVs(85, 85, 85, 85, 85, 85);

			Assert.AreEqual(arceus.HP, 371, $"HP stat should be 371, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk, 266, $"Atk stat should be 266, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def, 266, $"Def stat should be 266, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk, 266, $"SpAtk stat should be 266, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef, 266, $"SpDef stat should be 266, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd, 266, $"Spd stat should be 266, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonEVsExceptions()
		{
			var arceus = new Arceus(100);

			Assert.ThrowsException<ArgumentException>(() => arceus.setEVs(100, 100, 100, 100, 100, 11), "EVs whose total surpass 510 were accepted, whereas it should not");
			Assert.ThrowsException<ArgumentException>(() => arceus.setEVs(256, 0, 0, 0, 0, 0), "EV above 252 was accepted, whereas it should not");
		}
	}
}