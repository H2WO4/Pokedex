using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokeMoves;


namespace Pokedex;

public static class Program
{
    public static readonly Random Rnd = new();

    private static IEnumerable<Pokemon> PokeListBase
    {
        get
        {
            var dragonite = new Pokemon(Dragonite.Singleton, 100);
            dragonite.SetMoves(new MoveDragonDance(), new MoveEarthquake(),
                               new MoveIcePunch(), new MoveRoost());

            var blissey = new Pokemon(Blissey.Singleton, 100);
            blissey.SetMoves(new MoveSeismicToss(), new MoveSoftBoiled(),
                             new MoveTeleport(), new MoveThunderWave());

            var kartana = new Pokemon(Kartana.Singleton, 100);
            kartana.SetMoves(new MoveLeafBlade(), new MoveSmartStrike(),
                             new MoveSwordsDance(), new MoveGigaImpact());

            var mew = new Pokemon(Mew.Singleton, 100);
            mew.SetMoves(new MoveCosmicPower(), new MoveRoost(),
                         new MoveFlareBlitz(), new MoveWillOWisp());

            var ninetails = new Pokemon(NinetalesAlola.Singleton, 100);
            ninetails.SetMoves(new MoveFreezeDry(), new MoveHail(),
                               new MoveHypnosis(), new MoveBlizzard());

            var melmetal = new Pokemon(Melmetal.Singleton, 100);
            melmetal.SetMoves(new MoveSuperpower(), new MoveThunderPunch(),
                              new MoveThunderWave(), new MoveToxic());

            var slowbro = new Pokemon(Slowbro.Singleton, 100);
            slowbro.SetMoves(new MoveScald(), new MoveSlackOff(),
                             new MoveTeleport(), new MoveHeadbutt());

            var toxapex = new Pokemon(Toxapex.Singleton, 100);
            toxapex.SetMoves(new MoveScald(), new MoveRecover(),
                             new MovePoisonJab(), new MoveToxic());

            var tyranitar = new Pokemon(Tyranitar.Singleton, 100);
            tyranitar.SetMoves(new MoveRockBlast(), new MoveEarthquake(),
                               new MoveToxic(), new MoveThunderWave());

            var victini = new Pokemon(Victini.Singleton, 100);
            victini.SetMoves(new MoveVCreate(), new MoveBoltStrike(),
                             new MoveUTurn(), new MoveGlaciate());

            var zapdos = new Pokemon(Zapdos.Singleton, 100);
            zapdos.SetMoves(new MoveVoltSwitch(), new MoveRoost(),
                            new MoveHurricane(), new MoveHeatWave());

            var bisharp = new Pokemon(Bisharp.Singleton, 100);
            bisharp.SetMoves(new MoveSwordsDance(), new MoveIronHead(),
                             new MoveGuillotine(), new MoveFoulPlay());

            var dragapult = new Pokemon(Dragapult.Singleton, 100);
            dragapult.SetMoves(new MoveShadowBall(), new MoveDracoMeteor(),
                               new MoveUTurn(), new MoveFlamethrower());

            var landorus = new Pokemon(LandorusTherian.Singleton, 100);
            landorus.SetMoves(new MoveSwordsDance(), new MoveEarthquake(),
                              new MoveStoneEdge(), new MoveRockPolish());

            var tapukoko = new Pokemon(TapuKoko.Singleton, 100);
            tapukoko.SetMoves(new MoveThunderbolt(), new MoveDazzlingGleam(),
                              new MoveUTurn(), new MoveRoost());

            var volcarona = new Pokemon(Volcarona.Singleton, 100);
            volcarona.SetMoves(new MoveQuiverDance(), new MoveFireBlast(),
                               new MoveBugBuzz(), new MoveGigaDrain());

            yield return dragonite;
            yield return blissey;
            yield return kartana;
            yield return mew;
            yield return ninetails;
            yield return melmetal;
            yield return slowbro;
            yield return toxapex;
            yield return tyranitar;
            yield return victini;
            yield return zapdos;
            yield return bisharp;
            yield return dragapult;
            yield return landorus;
            yield return tapukoko;
            yield return volcarona;
        }
    }

    private static readonly List<Pokemon> PokeList = PokeListBase.ToList();

    public static void Main(string[ ] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        PokeType.InitializeTypes();

        // Presentation
        Console.WriteLine("Welcome to the Grand Pokemon Championship!");
        Console.WriteLine("Here on my left is our first contestant, I call ...");
        Console.Write("(Eh, sorry, what's your name again?) ");
        string nameA = Console.ReadLine()!;
        Console.WriteLine($"As I was saying, I call {nameA} to the stand!");
        Console.WriteLine("Here on my right is their opponent, I call ...");
        Console.Write("(I'm very bad with names, could you tell me yours again?) ");
        string nameB = Console.ReadLine()!;
        Console.WriteLine($"I call {nameB} to the stand!");

        Console.WriteLine();
        Console.WriteLine("I'm going to present you a list of 16 Pokemons, and you're going to choose 6, one at a time.");
        bool firstPlayer = Rnd.Next(0, 2) == 0;
        Console.WriteLine($"And the first to go will be ... {(firstPlayer ? nameA : nameB)}!");

        List<I_Battler> teamA = new(),
                        teamB = new();

        while (teamA.Count < 6
            && teamB.Count < 6)
        {
            if (firstPlayer)
            {
                ChoosePokemon(teamA);
                Console.WriteLine();
                ChoosePokemon(teamB);
            } else
            {
                ChoosePokemon(teamB);
                Console.WriteLine();
                ChoosePokemon(teamA);
            }

            Console.WriteLine();
        }

        Console.WriteLine("Very good!");
        Console.WriteLine("Now let the fight ... commence!");

        Trainer playerA = new(nameA, teamA.ToArray()),
                playerB = new(nameB, teamB.ToArray());

        Combat   octogon = new(playerA, playerB);
        I_Player winner  = octogon.DoCombat();

        Console.WriteLine($"And the winner is ... {winner.Name}");
    }

    private static void ChoosePokemon(ICollection<I_Battler> team)
    {
        for (var i = 0; i < PokeList.Count; i++)
        {
            Pokemon poke = PokeList[i];
            Console.WriteLine($"{i + 1}: {poke}");
        }

        do
        {
            Console.Write("Choose a pokemon: ");
            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int pokeNum) is false)
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            pokeNum--;

            if (pokeNum < 0
             || pokeNum >= PokeList.Count)
            {
                Console.WriteLine("Input out of bounds");
                continue;
            }

            Console.WriteLine($"{PokeList[pokeNum]} was chosen!");
            team.Add(PokeList[pokeNum]);
            PokeList.RemoveAt(pokeNum);
        } while (false);
    }
}