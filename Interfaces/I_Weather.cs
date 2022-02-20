using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface I_Weather
    {
        # region Properties
        string Name { get; }
        # endregion

        # region Methods
        void OnEnter();
        void OnExit();

        void OnTurnEnd(CombatInstance context);

        double OnDamageGive(double damage, PokemonType type);
        # endregion
    }
}