using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Pokemons;

namespace Pokedex.Tests;

[TestClass]
public class TestPokemonClass
{
	[TestMethod]
	public void PokemonAttributes()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100, "Arcy");

		Assert.AreEqual("Arceus", arceus.SpeciesName, $"Name should be 'Arceus', is {arceus.Name}");
		Assert.AreEqual("Arcy", arceus.Name, $"Nickname should be 'Arcy', is {arceus.Name}");
		Assert.AreEqual("Alpha Pokémon", arceus.Genus, $"Genus should be 'Alpha Pokémon', is {arceus.Genus}");
		Assert.AreEqual(493, arceus.ID, $"ID should be 493', is {arceus.ID}");
	}

	[TestMethod]
	public void PokemonStats()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100)
			{ Nature = Nature.Hardy };
		arceus.SetIVs(0, 0, 0, 0, 0, 0);
		arceus.SetEVs(0, 0, 0, 0, 0, 0);

		Assert.AreEqual(350, arceus.HP(), $"HP stat should be 350, is {arceus.HP()}");
		Assert.AreEqual(245, arceus.Atk(), $"Atk stat should be 245, is {arceus.Atk()}");
		Assert.AreEqual(245, arceus.Def(), $"Def stat should be 245, is {arceus.Def()}");
		Assert.AreEqual(245, arceus.SpAtk(), $"SpAtk stat should be 245, is {arceus.SpAtk()}");
		Assert.AreEqual(245, arceus.SpDef(), $"SpDef stat should be 245, is {arceus.SpDef()}");
		Assert.AreEqual(245, arceus.Spd(), $"Spd stat should be 245, is {arceus.Spd()}");
	}

	[TestMethod]
	public void PokemonIVs()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100)
			{ Nature = Nature.Hardy };
		arceus.SetIVs(31, 31, 31, 31, 31, 31);
		arceus.SetEVs(0, 0, 0, 0, 0, 0);

		Assert.AreEqual(381, arceus.HP(), $"HP stat should be 381, is {arceus.HP()}");
		Assert.AreEqual(276, arceus.Atk(), $"Atk stat should be 276, is {arceus.Atk()}");
		Assert.AreEqual(276, arceus.Def(), $"Def stat should be 276, is {arceus.Def()}");
		Assert.AreEqual(276, arceus.SpAtk(), $"SpAtk stat should be 276, is {arceus.SpAtk()}");
		Assert.AreEqual(276, arceus.SpDef(), $"SpDef stat should be 276, is {arceus.SpDef()}");
		Assert.AreEqual(276, arceus.Spd(), $"Spd stat should be 276, is {arceus.Spd()}");
	}

	[TestMethod]
	public void PokemonEVs()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100)
			{ Nature = Nature.Hardy };
		arceus.SetIVs(0, 0, 0, 0, 0, 0);
		arceus.SetEVs(85, 85, 85, 85, 85, 85);

		Assert.AreEqual(371, arceus.HP(), $"HP stat should be 371, is {arceus.HP()}");
		Assert.AreEqual(266, arceus.Atk(), $"Atk stat should be 266, is {arceus.Atk()}");
		Assert.AreEqual(266, arceus.Def(), $"Def stat should be 266, is {arceus.Def()}");
		Assert.AreEqual(266, arceus.SpAtk(), $"SpAtk stat should be 266, is {arceus.SpAtk()}");
		Assert.AreEqual(266, arceus.SpDef(), $"SpDef stat should be 266, is {arceus.SpDef()}");
		Assert.AreEqual(266, arceus.Spd(), $"Spd stat should be 266, is {arceus.Spd()}");
	}

	[TestMethod]
	public void PokemonEVsExceptions()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100);

		// * Singular EV assignment
		Assert.ThrowsException<ArgumentException>
		(
			() => arceus.SetEV(Stat.Atk, 253),
			"EV above 252 was accepted, whereas it should not"
		);
		Assert.ThrowsException<ArgumentException>
		(
			() => arceus.SetEV(Stat.Atk, -1),
			"Negative EV was accepted, whereas it should not"
		);
		arceus.SetEVs(100, 100, 100, 100, 100, 0);
		Assert.ThrowsException<ArgumentException>
		(
			() => arceus.SetEV(Stat.Spd, 11),
			"EV putting total EVs above 510 was accepted, whereas it should not"
		);

		// * Multi-EV assignment
		Assert.ThrowsException<ArgumentException>
		(
			() => arceus.SetEVs(100, 100, 100, 100, 100, 11),
			"EVs whose total surpass 510 were accepted, whereas it should not"
		);
		Assert.ThrowsException<ArgumentException>
		(
			() => arceus.SetEVs(253, 0, 0, 0, 0, 0),
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
		var arceus = new Pokemon(Arceus.Singleton, 100);
		arceus.SetIVs(0, 0, 0, 0, 0, 0);
		arceus.SetEVs(0, 0, 0, 0, 0, 0);

		arceus.Nature = Nature.Lonely;
		Assert.AreEqual(269, arceus.Atk(), $"Atk stat should be 269, is {arceus.Atk()}");
		Assert.AreEqual(220, arceus.Def(), $"Def stat should be 220, is {arceus.Def()}");

		arceus.Nature = Nature.Rash;
		Assert.AreEqual(269, arceus.SpAtk(), $"SpAtk stat should be 269, is {arceus.SpAtk()}");
		Assert.AreEqual(220, arceus.SpDef(), $"SpDef stat should be 220, is {arceus.SpDef()}");

		arceus.Nature = Nature.Timid;
		Assert.AreEqual(269, arceus.Spd(), $"Spd stat should be 269, is {arceus.Spd()}");
		Assert.AreEqual(220, arceus.Atk(), $"Atk stat should be 220, is {arceus.Atk()}");

		arceus.Nature = Nature.Impish;
		Assert.AreEqual(269, arceus.Def(), $"Def stat should be 269, is {arceus.Def()}");
		Assert.AreEqual(220, arceus.SpAtk(), $"SpAtk stat should be 220, is {arceus.SpAtk()}");

		arceus.Nature = Nature.Sassy;
		Assert.AreEqual(269, arceus.SpDef(), $"SpDef stat should be 269, is {arceus.SpDef()}");
		Assert.AreEqual(220, arceus.Spd(), $"Spd stat should be 220, is {arceus.Spd()}");
	}
	
	[TestMethod]
	public void PokemonStatBoosts()
	{
		var arceus = new Pokemon(Arceus.Singleton, 100)
			{ Nature = Nature.Hardy };
		arceus.SetIVs(0, 0, 0, 0, 0, 0);
		arceus.SetEVs(0, 0, 0, 0, 0, 0);

		arceus.SetBoosts(+6, +6, +6, +6, +6);
		Assert.AreEqual(980, arceus.Atk(), $"Atk stat should be 980, is {arceus.Atk()}");
		Assert.AreEqual(980, arceus.Def(), $"Def stat should be 980, is {arceus.Def()}");
		Assert.AreEqual(980, arceus.SpAtk(), $"SpAtk stat should be 980, is {arceus.SpAtk()}");
		Assert.AreEqual(980, arceus.SpDef(), $"SpDef stat should be 980, is {arceus.SpDef()}");
		Assert.AreEqual(980, arceus.Spd(), $"Spd stat should be 980, is {arceus.Spd()}");

		arceus.SetBoosts(-6, -6, -6, -6, -6);
		Assert.AreEqual(61, arceus.Atk(), $"Atk stat should be 61, is {arceus.Atk()}");
		Assert.AreEqual(61, arceus.Def(), $"Def stat should be 61, is {arceus.Def()}");
		Assert.AreEqual(61, arceus.SpAtk(), $"SpAtk stat should be 61, is {arceus.SpAtk()}");
		Assert.AreEqual(61, arceus.SpDef(), $"SpDef stat should be 61, is {arceus.SpDef()}");
		Assert.AreEqual(61, arceus.Spd(), $"Spd stat should be 61, is {arceus.Spd()}");
	}
}