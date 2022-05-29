using Pokedex.Enums;

namespace Pokedex.Models.Abilities;

public class AbilityMoody : Ability
{
    #region Constructors
    public AbilityMoody(Pokemon origin)
        : base("Moody", origin) { }
    #endregion

    #region Methods
    public override void OnTurnStart()
    {
        Announce();
        Stat[] stats = { Stat.Attack, Stat.Defense, Stat.SpecialAttack, Stat.SpecialDefense, Stat.Speed };

        Stat plusStat = stats.Where(stat => Origin.StatBoosts[stat] != +6)
                             .OrderBy(_ => Program.Rnd.Next())
                             .First();
        Stat minusStat = stats.Where(stat => Origin.StatBoosts[stat] != -6)
                              .Where(stat => stat != plusStat)
                              .OrderBy(_ => Program.Rnd.Next())
                              .First();

        if (plusStat != 0)
            Origin.ChangeStatBonus(plusStat, +2);
        if (minusStat != 0)
            Origin.ChangeStatBonus(minusStat, -1);
    }
    #endregion
}