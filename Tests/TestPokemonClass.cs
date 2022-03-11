using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Enums;
using Pokedex.Models.Pokemons;

namespace Tests
{
	[TestClass]
	public class TestPokemonClass
	{
		[TestMethod]
		public void PokemonAttributes()
		{
			var arceus = new Arceus(100);
			arceus.Name = "Arcy";

			Assert.AreEqual(arceus.Name, "Arceus", $"Name should be 'Arceus', is {arceus.Name}");
			Assert.AreEqual(arceus.Name, "Arcy", $"Nickname should be 'Arcy', is {arceus.Name}");
			Assert.AreEqual(arceus.Genus, "Alpha Pokémon", $"Genus should be 'Alpha Pokémon', is {arceus.Genus}");
			Assert.AreEqual(arceus.ID, 493, $"ID should be 493', is {arceus.ID}");
		}

		[TestMethod]
		public void PokemonStats()
		{
			var arceus = new Arceus(100);
			arceus.SetIVs(0, 0, 0, 0, 0, 0);
			arceus.SetEVs(0, 0, 0, 0, 0, 0);
			arceus.Nature = Nature.Hardy;

			Assert.AreEqual(arceus.HP(), 350, $"HP stat should be 350, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk(), 245, $"Atk stat should be 245, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 245, $"Def stat should be 245, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 245, $"SpAtk stat should be 245, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 245, $"SpDef stat should be 245, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 245, $"Spd stat should be 245, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonIVs()
		{
			var arceus = new Arceus(100);
			arceus.SetIVs(31, 31, 31, 31, 31, 31);
			arceus.SetEVs(0, 0, 0, 0, 0, 0);
			arceus.Nature = Nature.Hardy;

			Assert.AreEqual(arceus.HP(), 381, $"HP stat should be 381, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk(), 276, $"Atk stat should be 276, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 276, $"Def stat should be 276, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 276, $"SpAtk stat should be 276, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 276, $"SpDef stat should be 276, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 276, $"Spd stat should be 276, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonEVs()
		{
			var arceus = new Arceus(100);
			arceus.SetIVs(0, 0, 0, 0, 0, 0);
			arceus.SetEVs(85, 85, 85, 85, 85, 85);
			arceus.Nature = Nature.Hardy;

			Assert.AreEqual(arceus.HP(), 371, $"HP stat should be 371, is {arceus.HP}");
			Assert.AreEqual(arceus.Atk(), 266, $"Atk stat should be 266, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 266, $"Def stat should be 266, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 266, $"SpAtk stat should be 266, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 266, $"SpDef stat should be 266, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 266, $"Spd stat should be 266, is {arceus.Spd}");
		}

		[TestMethod]
		public void PokemonEVsExceptions()
		{
			var arceus = new Arceus(100);

			// * Singular EV assignement
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEV("atk", 253),
				"EV above 252 was accepted, whereas it should not"
			);
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEV("atk", -1),
				"Negative EV was accepted, whereas it should not"
			);
			arceus.SetEVs(100, 100, 100, 100, 100, 0);
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEV("spd", 11),
				"EV putting total EVs above 510 was accepted, whereas it should not"
			);

			// * Multi-EV assignement
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEVs(100, 100, 100, 100, 100, 11),
				"EVs whose total surpass 510 were accepted, whereas it should not"
			);
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEVs(256, 0, 0, 0, 0, 0),
				"EV above 252 was accepted, whereas it should not"
			);
			Assert.ThrowsException<ArgumentException>
			(
				() => arceus.SetEVs(-1, 0, 0, 0, 0, 0),
				"Negative EV was accepted, whereas it should not"
			);
		}

		[TestMethod]
		public void PokemonNature()
		{
			var arceus = new Arceus(100);
			arceus.SetIVs(0, 0, 0, 0, 0, 0);
			arceus.SetEVs(0, 0, 0, 0, 0, 0);

			arceus.Nature = Nature.Lonely;
			Assert.AreEqual(arceus.Atk(), 269, $"Atk stat should be 269, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 220, $"Def stat should be 220, is {arceus.Def}");

			arceus.Nature = Nature.Rash;
			Assert.AreEqual(arceus.SpAtk(), 269, $"SpAtk stat should be 269, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 220, $"SpDef stat should be 220, is {arceus.SpDef}");

			arceus.Nature = Nature.Timid;
			Assert.AreEqual(arceus.Spd(), 269, $"Spd stat should be 269, is {arceus.Spd}");
			Assert.AreEqual(arceus.Atk(), 220, $"Atk stat should be 220, is {arceus.Atk}");

			arceus.Nature = Nature.Impish;
			Assert.AreEqual(arceus.Def(), 269, $"Def stat should be 269, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 220, $"SpAtk stat should be 220, is {arceus.SpAtk}");

			arceus.Nature = Nature.Sassy;
			Assert.AreEqual(arceus.SpDef(), 269, $"SpDef stat should be 269, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 220, $"Spd stat should be 220, is {arceus.Spd}");
		}
	
		[TestMethod]
		public void PokemonStatBoosts()
		{
			var arceus = new Arceus(100);
			arceus.SetIVs(0, 0, 0, 0, 0, 0);
			arceus.SetEVs(0, 0, 0, 0, 0, 0);
			arceus.Nature = Nature.Hardy;

			arceus.SetBoosts(+6, +6, +6, +6, +6);
			Assert.AreEqual(arceus.Atk(), 980, $"Atk stat should be 980, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 980, $"Def stat should be 980, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 980, $"SpAtk stat should be 980, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 980, $"SpDef stat should be 980, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 980, $"Spd stat should be 980, is {arceus.Spd}");

			arceus.SetBoosts(-6, -6, -6, -6, -6);
			Assert.AreEqual(arceus.Atk(), 61, $"Atk stat should be 61, is {arceus.Atk}");
			Assert.AreEqual(arceus.Def(), 61, $"Def stat should be 61, is {arceus.Def}");
			Assert.AreEqual(arceus.SpAtk(), 61, $"SpAtk stat should be 61, is {arceus.SpAtk}");
			Assert.AreEqual(arceus.SpDef(), 61, $"SpDef stat should be 61, is {arceus.SpDef}");
			Assert.AreEqual(arceus.Spd(), 61, $"Spd stat should be 61, is {arceus.Spd}");
		}
	}
}