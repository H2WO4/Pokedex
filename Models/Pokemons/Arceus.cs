using Pokedex.Models.PokeTypes;
using Pokedex.Enums;

namespace Pokedex.Models.Pokemons
{
    public class Arceus : PokeSpecies
    {
        #region Class Variables
        private static Arceus? _singleton;
        #endregion

        #region Properties
        public static Arceus Singleton
            => _singleton ??= new Arceus();
        #endregion

        #region Constructor
        public Arceus()
            : base(493, "Arceus",
                   new List<PokeType> { TypeNormal.Singleton },
                   new Dictionary<Stat, int>
                   {
                       { Stat.HP, 120 }, { Stat.Attack, 120 }, { Stat.Defense, 120 },
                       { Stat.SpecialAttack, 120 }, { Stat.SpecialDefense, 120 }, { Stat.Speed, 120 },
                   },
                   4, "Alpha Pokémon", PokeClass.Mythical,
                   32, 3200) { }
        #endregion
    }
}