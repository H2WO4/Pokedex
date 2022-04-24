using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Abilities;

public class AbilityNormalize : Ability
{
    #region Variables
    private PokeType _tempType = TypeNormal.Singleton;
    private int? _tempPower;
    #endregion
    
    #region Constructors
    public AbilityNormalize(Pokemon origin)
        : base("Normalize", origin) { }
    #endregion

    #region Methods
    public override bool BeforeAttack(I_Skill move)
    {
        _tempType = move.Type;
        move.Type = TypeNormal.Singleton;

        _tempPower = move.Power;
        if (move.Power is not null)
            move.Power *= (int)(move.Power * 1.2);

        return false;
    }

    public override void AfterAttack(I_Skill move)
    {
        move.Type = _tempType;
        if (move.Power is not null)
            move.Power = _tempPower;
    }
    #endregion
}