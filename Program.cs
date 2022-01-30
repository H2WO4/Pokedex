using Pokemons.Models;
using Pokemons.Enums;
using System.Reflection;
using Pokemons.Models.PokemonSkills;
using Pokemons.Models.PokemonTypes;

namespace Pokemons
{
	class Program
	{
		static void Main(String[] args)
		{
			initializeTypes();
			
			/* Random random = new Random();
			Assembly.GetAssembly(typeof(Pokemon))!.GetTypes() // Load the object Pokemon
				.Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Pokemon))) // Take all of its subclasses
				.Select(type => (Pokemon?)Activator.CreateInstance(type, new object[]{ random.Next(1, 100) })!).ToList() // Instantiate them
				//.Where(poke => poke.Species.Class == PokeClass.Mythical) // Filter them
				.OrderBy(_ => random.Next()) // Shuffle them
				.Take(10).ToList() // Take 10 of them
				.ForEach(poke => Console.WriteLine($"{poke.PokedexEntry}\n")); // Print them */
			
			PokemonType.displayAffinityTable();
		}

		static void initializeTypes()
		{
			TypeNormal.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 0.5}, {"Ghost", 0},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 2}
			});
			TypeFire.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 0.5}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 2}, {"Fairy", 1}
			});
			TypeWater.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 2}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 1}, {"Fairy", 1}
			});
			TypeElectric.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 2}, {"Electric", 0.5},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 0}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 1}, {"Fairy", 1}
			});
			TypeGrass.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 2}, {"Electric", 1},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 0.5},
				{"Ground", 2}, {"Flying", 0.5},
				{"Psychic", 1}, {"Bug", 0.5},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeIce.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 0.5},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 2}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 2}, {"Fairy", 1}
			});
			TypeFighting.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 2}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 0.5}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 0.5},
				{"Psychic", 2}, {"Bug", 0.5},
				{"Rock", 2}, {"Ghost", 0.5},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 0.5}, {"Fairy", 0}
			});
			TypePoison.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 0.5}, {"Poison", 0.5},
				{"Ground", 0.5}, {"Flying", 0.5},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 0.5},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeGround.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 0.5}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 2},
				{"Ground", 1}, {"Flying", 0},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 2}, {"Fairy", 1}
			});
			TypeFlying.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 0.5},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 0.5},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 0.5}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypePsychic.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 0.5}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 0},
				{"Steel", 1}, {"Fairy", 1}
			});
			TypeBug.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 1}, {"Electric", 0.5},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 0.5}, {"Poison", 2},
				{"Ground", 1}, {"Flying", 2},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 0.5},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeRock.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 2}, {"Poison", 1},
				{"Ground", 0.5}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeGhost.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 0}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 2},
				{"Dragon", 1}, {"Dark", 0.5},
				{"Steel", 1}, {"Fairy", 1}
			});
			TypeDragon.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 0.5}, {"Ghost", 1},
				{"Dragon", 2}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeDark.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 0.5}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 2},
				{"Dragon", 1}, {"Dark", 0.5},
				{"Steel", 1}, {"Fairy", 1}
			});
			TypeSteel.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 0.5},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1}
			});
			TypeFairy.Singleton.setAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 2}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 0.5}
			});

		}
	}
}