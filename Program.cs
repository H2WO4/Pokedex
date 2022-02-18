using Pokedex.Models;
using Pokedex.Enums;
using System.Reflection;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokemonSkills;
using Pokedex.Models.PokemonTypes;

namespace Pokedex
{
	class Program
	{
		static void initializeTypes()
		{
			TypeNormal.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 0.5}, {"Ghost", 0},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 2},
				{"Light", 1}
			});
			TypeFire.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 0.5}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 2}, {"Fairy", 1},
				{"Light", 1}
			});
			TypeWater.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 2}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 1}, {"Fairy", 1},
				{"Light", 0.5}
			});
			TypeElectric.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 2}, {"Electric", 0.5},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 0}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 1}, {"Fairy", 1},
				{"Light", 0.5}
			});
			TypeGrass.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 2}, {"Electric", 1},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 0.5},
				{"Ground", 2}, {"Flying", 0.5},
				{"Psychic", 1}, {"Bug", 0.5},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 0.5}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1},
				{"Light", 1}
			});
			TypeIce.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 0.5},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 2}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 2}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1},
				{"Light", 2}
			});
			TypeFighting.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 2}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 0.5},
				{"Psychic", 0.5}, {"Bug", 0.5},
				{"Rock", 2}, {"Ghost", 0},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 2}, {"Fairy", 0.5},
				{"Light", 1}
			});
			TypePoison.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 0.5},
				{"Ground", 0.5}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 0.5}, {"Ghost", 0.5},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0}, {"Fairy", 2},
				{"Light", 1}
			});
			TypeGround.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 1}, {"Electric", 2},
				{"Grass", 0.5}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 2},
				{"Ground", 1}, {"Flying", 0},
				{"Psychic", 1}, {"Bug", 0.5},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 2}, {"Fairy", 1},
				{"Light", 0.5}
			});
			TypeFlying.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 0.5},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 0.5},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 0.5}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1},
				{"Light", 1}
			});
			TypePsychic.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 0.5}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 2},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 0.5}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 0},
				{"Steel", 2}, {"Fairy", 1},
				{"Light", 2}
			});
			TypeBug.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 1}, {"Electric", 0.5},
				{"Grass", 2}, {"Ice", 1},
				{"Fighting", 0.5}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 0.5},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 0.5},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 0.5}, {"Fairy", 0.5},
				{"Light", 1}
			});
			TypeRock.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 2},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 0.5}, {"Poison", 1},
				{"Ground", 0.5}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 2},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 1},
				{"Light", 1}
			});
			TypeGhost.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 0}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 2},
				{"Dragon", 1}, {"Dark", 0.5},
				{"Steel", 1}, {"Fairy", 1},
				{"Light", 1}
			});
			TypeDragon.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 0.5},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 2},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 2}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 0},
				{"Light", 2}
			});
			TypeDark.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 0.5}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 2}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 2},
				{"Dragon", 1}, {"Dark", 0.5},
				{"Steel", 1}, {"Fairy", 0.5},
				{"Light", 2}
			});
			TypeSteel.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 0.5}, {"Electric", 0.5},
				{"Grass", 1}, {"Ice", 2},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 2}, {"Ghost", 1},
				{"Dragon", 1}, {"Dark", 1},
				{"Steel", 0.5}, {"Fairy", 2},
				{"Light", 1}
			});
			TypeFairy.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 0.5},
				{"Water", 1}, {"Electric", 1},
				{"Grass", 1}, {"Ice", 1},
				{"Fighting", 2}, {"Poison", 0.5},
				{"Ground", 1}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 1},
				{"Dragon", 2}, {"Dark", 2},
				{"Steel", 0.5}, {"Fairy", 1},
				{"Light", 0}
			});
			TypeLight.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 1}, {"Fire", 1},
				{"Water", 2}, {"Electric", 2},
				{"Grass", 1}, {"Ice", 0.5},
				{"Fighting", 1}, {"Poison", 1},
				{"Ground", 0.5}, {"Flying", 1},
				{"Psychic", 1}, {"Bug", 1},
				{"Rock", 1}, {"Ghost", 2},
				{"Dragon", 1}, {"Dark", 2},
				{"Steel", 1}, {"Fairy", 0},
				{"Light", 0.5}
			});

		}

		static void Main(String[] args)
		{
			var arceus = new Arceus(100);
			Console.WriteLine(arceus.StatusAlly);

			/* initializeTypes();
			var arceus = new Arceus(100);
			Console.WriteLine(arceus.PokedexEntry); */

			/* var thunder = new SkillThunder();

			Random random = new Random();
			Assembly.GetAssembly(typeof(Pokemon))!.GetTypes() // Load the object Pokemon
				.Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Pokemon))) // Take all of its subclasses
				.Select(type => (Pokemon?)Activator.CreateInstance(type, new object[]{ random.Next(1, 100) })!).ToList() // Instantiate them
				// .Where(poke => poke.Species.Class == PokeClass.Mythical) // Filter them
				.OrderBy(_ => random.Next()) // Shuffle them
				.Take(10).ToList() // Take 10 of them
				.ForEach(poke => Console.WriteLine($"{poke.PokedexEntry}\n")); // Print them */
			
			// PokemonType.displayAffinityTable();
			// Console.WriteLine(thunder.PokedexEntry);
		}
	}
}