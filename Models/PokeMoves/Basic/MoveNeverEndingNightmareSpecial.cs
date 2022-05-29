using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveNeverEndingNightmareSpecial : PokeMove
{
    public MoveNeverEndingNightmareSpecial()
        : base("Never Ending Nightmare  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGhost.Singleton) { }
}