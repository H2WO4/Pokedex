using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Utils;

namespace Pokedex.Models;

public static class DamageHandler
{
    #region Methods
    public static bool DoDamage(DamageInfo dmgInfo, I_Battler caster, I_Battler target)
    {
        // If the caster or the target is dead, cancel the damage
        if (caster.CurrHP == 0
         || target.CurrHP == 0)
            return false;

        // Activate abilities and cancel the damage if necessary
        var cancel = false;
        // If the caster and target are different entities, do as normal
        if (caster != target)
        {
            cancel |= caster.Ability.OnInflictDamage(dmgInfo, target);
            cancel |= target.Ability.OnReceiveDamage(dmgInfo, caster);
        }
        // Otherwise, it's a case of self-inflicted damage
        else
            cancel |= caster.Ability.OnSelfDamage(dmgInfo);

        // If any of the abilities asked for damage cancellation, do it
        if (cancel) return false;

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
        int percentage = Math.Clamp((int)damage * 100 / target.HP(), 0, 100);
        Console.WriteLine($"{target.Name} lost {percentage}% HP");

        // Apply the damage
        target.CurrHP -= (int)damage;

        // Activate post-damage abilities
        caster.Ability.AfterInflictDamage(dmgInfo, target);
        target.Ability.AfterReceiveDamage(dmgInfo, caster);

        // Indicate that everything went smoothly
        return true;
    }

    private static double CalculateDamage(DamageInfo dmgInfo, I_Battler caster, I_Battler target)
    {
        double damage = 0;
        switch (dmgInfo)
        {
            case { Class: DamageClass.Pure }:
                // Calculate the damage
                damage = dmgInfo.Power;

                break;

            case { Class: DamageClass.Percent }:
                // Calculate the damage
                damage = target.HP() * dmgInfo.Power / 100d;

                break;

            case { Class: DamageClass.Calculated, Type: { } type }:
                // Initial damage
                damage = (0.4 * caster.Level + 2) * dmgInfo.Power;

                // Find which stat to use
                IEnumerable<Stat> atkStats = dmgInfo.AttackStats.GetFlags();
                IEnumerable<Stat> defStats = dmgInfo.DefenseStats.GetFlags();
                
                // Adjust for stats
                double multiplier = 1;
                multiplier *= atkStats
                   .Average(caster.GetStat);
                multiplier /= defStats
                   .Average(target.GetStat);
                damage *= multiplier;

                // Continue the calculation
                damage = damage / 50 + 2;

                // Apply weather
                damage = target.Arena.Weather.OnDamageGive(damage, type);

                // Apply type weaknesses
                damage *= target.GetAffinity(type);

                break;
        }

        return damage;
    }
    #endregion
}