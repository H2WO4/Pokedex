using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Pokedex.Models;
using Pokedex.Models.PokemonMoves;
using Pokedex.Models.Pokemons;
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
				{"Rock", 0.5},
				{"Ghost", 0},
				{"Steel", 0.5},
				{"Fairy", 2},
			});
			TypeFire.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Water", 0.5},
				{"Grass", 2},
				{"Ice", 2},
				{"Bug", 2},
				{"Rock", 0.5},
				{"Dragon", 0.5},
				{"Steel", 2},
			});
			TypeWater.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 2},
				{"Water", 0.5},
				{"Grass", 0.5},
				{"Ground", 2},
				{"Rock", 2},
				{"Dragon", 0.5},
				{"Light", 0.5}
			});
			TypeElectric.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 2},
				{"Water", 2},
				{"Electric", 0.5},
				{"Grass", 0.5},
				{"Ground", 0}, {"Flying", 2},
				{"Dragon", 0.5},
				{"Light", 0.5}
			});
			TypeGrass.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Water", 2},
				{"Grass", 0.5},
				{"Poison", 0.5},
				{"Ground", 2},
				{"Flying", 0.5},
				{"Bug", 0.5},
				{"Rock", 2},
				{"Dragon", 0.5},
				{"Steel", 0.5},
			});
			TypeIce.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Water", 0.5},
				{"Grass", 2},
				{"Ice", 0.5},
				{"Ground", 2},
				{"Flying", 2},
				{"Dragon", 2},
				{"Steel", 0.5},
				{"Light", 2}
			});
			TypeFighting.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 2},
				{"Ice", 2},
				{"Poison", 0.5},
				{"Flying", 0.5},
				{"Psychic", 0.5},
				{"Bug", 0.5},
				{"Rock", 2},
				{"Ghost", 0},
				{"Dark", 2},
				{"Steel", 2},
				{"Fairy", 0.5},
			});
			TypePoison.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Grass", 2},
				{"Poison", 0.5},
				{"Ground", 0.5},
				{"Rock", 0.5},
				{"Ghost", 0.5},
				{"Steel", 0},
				{"Fairy", 2},
			});
			TypeGround.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 2},
				{"Electric", 2},
				{"Grass", 0.5},
				{"Poison", 2},
				{"Flying", 0},
				{"Bug", 0.5},
				{"Rock", 2},
				{"Steel", 2},
				{"Light", 0.5}
			});
			TypeFlying.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Electric", 0.5},
				{"Grass", 2},
				{"Fighting", 2},
				{"Flying", 0.5},
				{"Bug", 2},
				{"Rock", 0.5},
				{"Steel", 0.5},
			});
			TypePsychic.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 0.5},
				{"Fighting", 2},
				{"Poison", 2},
				{"Psychic", 0.5},
				{"Dark", 0},
				{"Steel", 2},
				{"Light", 2}
			});
			TypeBug.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Electric", 0.5},
				{"Grass", 2},
				{"Fighting", 0.5},
				{"Poison", 0.5},
				{"Flying", 0.5},
				{"Psychic", 2},
				{"Ghost", 0.5},
				{"Dark", 2},
				{"Steel", 0.5},
				{"Fairy", 0.5},
			});
			TypeRock.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 2},
				{"Ice", 2},
				{"Fighting", 0.5},
				{"Ground", 0.5},
				{"Flying", 2},
				{"Bug", 2},
				{"Steel", 0.5}
			});
			TypeGhost.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Normal", 0},
				{"Psychic", 2},
				{"Ghost", 2},
				{"Dark", 0.5},
			});
			TypeDragon.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Ice", 0.5},
				{"Flying", 2},
				{"Dragon", 2},
				{"Steel", 0.5}, {"Fairy", 0},
				{"Light", 2}
			});
			TypeDark.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fighting", 0.5},
				{"Psychic", 2},
				{"Ghost", 2},
				{"Dark", 0.5},
				{"Fairy", 0.5},
				{"Light", 2}
			});
			TypeSteel.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Water", 0.5},
				{"Electric", 0.5},
				{"Ice", 2},
				{"Rock", 2},
				{"Steel", 0.5},
				{"Fairy", 2},
			});
			TypeFairy.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Fire", 0.5},
				{"Fighting", 2},
				{"Poison", 0.5},
				{"Dragon", 2},
				{"Dark", 2},
				{"Steel", 0.5},
				{"Light", 0}
			});
			TypeLight.Singleton.SetAffinities(new Dictionary<string, double>(){
				{"Water", 2},
				{"Electric", 2},
				{"Ice", 0.5},
				{"Ground", 0.5},
				{"Ghost", 2},
				{"Dark", 2},
				{"Fairy", 0},
				{"Light", 0.5}
			});

		}

		static void Main(String[] args)
		{
			/* Console.OutputEncoding = System.Text.Encoding.UTF8;
			InitializeTypes();

			var raichu = new Raichu(100, "Pikachu");
			raichu.SetMoves(new MoveThunder(), new MoveSwordsDance(), null, null);
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

			fight.DoTurn(); */

			int test1(int i)
				=> i + 1;

			[Pure]
			[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
			int test2(int i)
				=> i + 1;

			var sw = new Stopwatch();
			var i = 0;

			sw.Start();
			for (; i < 10000000; i++) test1(5);
			sw.Stop();
			Console.WriteLine(sw.ElapsedTicks);

			i = 0;
			sw.Reset();

			sw.Start();
			for (; i < 10000000; i++) test2(5);
			sw.Stop();
			Console.WriteLine(sw.ElapsedTicks);

			Console.ReadLine();
		}
	}
}