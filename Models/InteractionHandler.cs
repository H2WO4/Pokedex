using System.Diagnostics.Contracts;

using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Utils;


namespace Pokedex.Models;

/// <summary>
/// Handles interactions between Pokemons
/// </summary>
public static class InteractionHandler
{
    #region Damage
    /// <summary>
    /// Inflict damage, as defined in the DamageInfo, on the target, from the caster
    /// </summary>
    /// <param name="dmgInfo">What damage to inflict</param>
    /// <param name="caster">The Pokemon initiating the damage</param>
    /// <param name="target">The Pokemon receiving the attack</param>
    /// <returns>The damage applied, or -1 if the damage was not applied</returns>
    public static double DoDamage(DamageInfo dmgInfo, I_Battler caster, I_Battler target)
    {
        // If the caster or the target is dead, cancel the damage
        if (caster.CurrHP == 0
         || target.CurrHP == 0)
            return -1;

        // Activate abilities and cancel the damage if necessary
        var cancel = false;
        // If the caster and target are different entities, do as normal
        if (caster != target)
        {
            cancel |= caster.Ability.OnInflictDamage(dmgInfo, target);
            cancel = caster.StatusEffects
                           .Aggregate(cancel, (current, effect) => current || effect.OnInflictDamage(dmgInfo, target));

            cancel |= target.Ability.OnReceiveDamage(dmgInfo, caster);
            cancel = target.StatusEffects
                           .Aggregate(cancel, (current, effect) => current || effect.OnReceiveDamage(dmgInfo, caster));
        }
        // Otherwise, it's a case of self-inflicted damage
        else
            cancel |= caster.Ability.OnSelfDamage(dmgInfo);

        // If any of the abilities asked for damage cancellation, do it
        if (cancel) return -1;

        // Calculate the damage, depending on the class of damage
        double damage = CalculateDamage(dmgInfo, caster, target);

        // If the damage would be lethal, activate abilities that could cancel death
        if (damage >= target.CurrHP)
        {
            int postDeathDamage = target.Ability.OnKilled(caster);
            damage -= postDeathDamage;

            // If the kill is confirmed, active the killer's ability
            if (postDeathDamage > 0)
                caster.Ability.OnKill();
        }

        // Announce the damage
        int percentage = Math.Clamp((int) damage * 100 / target.HP(), 0, 100);
        Console.WriteLine($"{target} lost {percentage}% HP");

        // Apply the damage
        target.CurrHP -= (int) damage;

        // Activate post-damage abilities
        caster.Ability.AfterInflictDamage(dmgInfo, target);
        target.Ability.AfterReceiveDamage(dmgInfo, caster);

        // Drain the correct amount of HP
        if (dmgInfo is { DrainPower: > 0 })
            DoHealing(new HealingInfo(CalcClass.Percent, dmgInfo.DrainPower), caster);

        // Indicate that everything went smoothly
        return damage;
    }

    /// <summary>
    /// Inflict damage, as defined in the DamageInfo, on the target
    /// </summary>
    /// <param name="dmgInfo">What damage to inflict</param>
    /// <param name="target">The Pokemon receiving the attack</param>
    /// <returns>Whether the damage was correctly applied</returns>
    public static double DoDamageNoCaster(DamageInfo dmgInfo, I_Battler target)
    {
        // If the target is dead, cancel the damage
        if (target.CurrHP == 0)
            return -1;

        // Activate abilities and cancel the damage if necessary
        var cancel = false;
        cancel |= target.Ability.OnReceiveDamage(dmgInfo);
        cancel = target.StatusEffects
                       .Aggregate(cancel, (current, effect) => current || effect.OnReceiveDamage(dmgInfo));


        // If any of the abilities asked for damage cancellation, do it
        if (cancel) return -1;

        // Calculate the damage, depending on the class of damage
        double damage = CalculateDamage(dmgInfo, null, target);

        // If the damage would be lethal, activate abilities that could cancel death
        if (damage >= target.CurrHP)
        {
            int postDeathDamage = target.Ability.OnKilled();
            damage -= postDeathDamage;
        }

        // Announce the damage
        int percentage = Math.Clamp((int) damage * 100 / target.HP(), 0, 100);
        Console.WriteLine($"{target} lost {percentage}% HP");

        // Apply the damage
        target.CurrHP -= (int) damage;

        // Activate post-damage abilities
        target.Ability.AfterReceiveDamage(dmgInfo);

        // Indicate that everything went smoothly
        return damage;
    }

    /// <summary>
    /// Calculate, from a DamageInfo, how much numerical damage to inflict
    /// </summary>
    /// <param name="dmgInfo">What damage to calculate</param>
    /// <param name="caster">The Pokemon initiating the damage</param>
    /// <param name="target">The Pokemon receiving the attack</param>
    /// <returns>The numerical amount of HP damage to inflict</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the DamageInfo possess impossible parameters combination
    /// </exception>
    [Pure]
    public static double CalculateDamage(DamageInfo dmgInfo, I_Battler? caster, I_Battler target)
    {
        double damage;
        switch (dmgInfo)
        {
            case { Class: CalcClass.Pure }:
                // Calculate the damage
                damage = dmgInfo.Power;

                break;

            case { Class: CalcClass.Percent, Type: { } type }:
                // Calculate the damage
                damage = target.HP() * dmgInfo.Power / 100d;

                // Apply STAB
                if (caster?.Types.Contains(type) is true)
                    dmgInfo.Power = (int) (dmgInfo.Power * 1.5);

                // Apply type weaknesses
                damage *= target.GetAffinity(type);

                break;

            case { Class: CalcClass.Percent, Type: null }:
                // Calculate the damage
                damage = target.HP() * dmgInfo.Power / 100d;

                break;

            case { Class: CalcClass.Calculated, Type: { } type }
                when caster is not null:
                // Initial damage
                damage = (0.4 * caster.Level + 2) * dmgInfo.Power;

                // Adjust for stats
                damage *= dmgInfo.AttackStats.GetFlags()
                                 .Average(caster.GetStat);
                damage /= dmgInfo.DefenseStats.GetFlags()
                                 .Average(target.GetStat);

                // Continue the calculation
                damage = damage / 50 + 2;

                // Apply STAB
                if (caster.Types.Contains(type))
                    dmgInfo.Power = (int) (dmgInfo.Power * 1.5);

                // Apply weather
                damage = target.Arena.Weather.OnDamageGive(damage, type);

                // Apply type weaknesses
                damage *= target.GetAffinity(type);

                break;

            case { Class: CalcClass.Calculated, Type: null }
                when caster is not null:
                // Initial damage
                damage = (0.4 * caster.Level + 2) * dmgInfo.Power;

                // Adjust for stats
                damage *= dmgInfo.AttackStats.GetFlags()
                                 .Average(caster.GetStat);
                damage /= dmgInfo.DefenseStats.GetFlags()
                                 .Average(target.GetStat);

                // Continue the calculation
                damage = damage / 50 + 2;

                break;

            default:
                throw new InvalidOperationException();
        }

        return damage;
    }
    #endregion

    #region Healing
    /// <summary>
    /// Heal the target as defined in the HealingInfo
    /// </summary>
    /// <param name="healInfo">What healing to inflict</param>
    /// <param name="target">The Pokemon receiving the healing</param>
    /// <returns>Whether the healing succeeded</returns>
    public static double DoHealing(HealingInfo healInfo, I_Battler target)
    {
        // If the target is dead, cancel the healing
        if (target.CurrHP == 0)
            return -1;

        // Calculate the healing
        double healing = CalculateHealing(healInfo, target);

        // Announce the healing
        int percentage = Math.Clamp((int) healing * 100 / target.HP(), 0, 100);
        Console.WriteLine($"{target} healed {percentage}% HP");
        
        // Apply the healing
        target.CurrHP += (int) healing;
        
        // Indicate that everything went smoothly
        return healing;
    }

    /// <summary>
    /// Calculate, from an HealingInfo, how much numerical healing to inflict
    /// </summary>
    /// <param name="healInfo">What healing to calculate</param>
    /// <param name="target">The Pokemon receiving the healing</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the HealingInfo possess impossible parameters combination
    /// </exception>
    [Pure]
    public static double CalculateHealing(HealingInfo healInfo, I_Battler target)
    {
        return healInfo switch
               {
                   { Class: CalcClass.Pure }    => healInfo.Power,
                   { Class: CalcClass.Percent } => target.HP() * healInfo.Power / 100d,

                   _ => throw new InvalidOperationException(),
               };
    }
    #endregion
}