using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Models.Pokemons;
using Pokedex.Models.PokemonSkills;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class TestCombatClass
    {
        [TestMethod]
        public void CombatTurn()
        {
            var teamA = new List<Pokemon>();
            var teamB = new List<Pokemon>();

            teamA.Add(new Arceus(100));
            teamA[0].SetMoves(new SkillThunder(), null, null, null);

            teamB.Add(new Arceus(100));
            teamB[0].SetMoves(new SkillThunder(), null, null, null);

            var combat = new CombatInstance(teamA, teamB);

            using (var reader = new StreamReader("..\\..\\..\\Tests\\test.txt"))
            {
                Console.SetIn(reader);
                combat.executeTurn();

                var queue = (List<I_Event>) typeof(CombatInstance).GetField("_eventQueue", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(combat)!;

                queue.ForEach(e => Console.WriteLine(e));
            }
        }
    }
}