using Pokedex.Models;
using Pokedex.Enums;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokemonMoves;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex
{
	class Program
	{
		public static Random rnd = new Random(0); 

		public static void InitializeTypes()
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
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			InitializeTypes();

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
			fight.Weather = WeatherRain.Singleton;

			// Redirect console
			using var reader = new StreamReader("Tests/test1_in.txt");
			// var writer = new StringWriter();
			using var writer = new StreamWriter("Tests/test1_out.ans");
			Console.SetIn(reader);
			Console.SetOut(writer);

			fight.DoTurn();
		}
	}
}