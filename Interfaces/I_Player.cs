using Pokedex.Models;

namespace Pokedex.Interfaces
{
    public interface I_Player
    {
        # region Properties
        Pokemon Active { get; }
        List<Pokemon> Bench { get; }
        string Name { get; }
        # endregion

        # region Methods
        void PlayTurn();
        # endregion
    }
}