using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMetronome : PokeMove, I_Skill
{
    public MoveMetronome()
        : base("Metronome",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    void I_Skill.DoAction(I_Battler target)
    {
        // Filter moves that cannot be obtained
        IEnumerable<PokeMove> eligibleMoves =
            AllMoves.Where(move => move.IsMeta is false)
                    .Where(move => Caster.Moves.Contains(move) is false);


        PokeMove useMove = eligibleMoves.OrderBy(_ => Program.Rnd.Next())
                                        .First();

        useMove.Caster = Caster;
        Console.WriteLine($"{useMove} comes out!");
        I_Skill.OnUse(useMove);
    }
}