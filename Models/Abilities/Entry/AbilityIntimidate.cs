using Pokedex.Enums;

namespace Pokedex.Models.Abilities;

public class AbilityIntimidate : Ability
{
    #region Constructors
    public AbilityIntimidate(Pokemon origin)
        : base("Intimidate", origin) { }
    #endregion

    #region Methods
    public override void OnEnter()
    {
        Announce();

        IEnumerable<Pokemon> opponentPokemons =
            Origin.Arena.Players
                  .Where(player => player != Origin.Owner)
                  .Select(player => player.Active)
                  .OfType<Pokemon>();

        foreach (Pokemon poke in opponentPokemons)
            poke.ChangeStatBonus(Stat.Atk, -1);
    }
    #endregion
}