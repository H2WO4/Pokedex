using System.Diagnostics.Contracts;

using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Events;


namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can be used by Pokemons
/// </summary>
public interface I_Skill
{
    #region Properties
    /// <summary>
    /// Name used for display
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The class the move belongs to
    /// </summary>
    MoveClass Class { get; }

    /// <summary>
    /// The damaging power of the move
    /// </summary>
    int? Power { get; set; }

    /// <summary>
    /// The chance out of 100 that the move has to hit its target
    /// </summary>
    int? Accuracy { get; set; }

    /// <summary>
    /// The type of the damage inflicted
    /// </summary>
    PokeType Type { get; set; }

    /// <summary>
    /// How much PP the move can have
    /// </summary>
    int MaxPP { get; }

    /// <summary>
    /// How much PP the move currently has
    /// </summary>
    int PP { get; }

    /// <summary>
    /// How much priority the event of using the move has in the event queue
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// The Pokemon who uses the move
    /// </summary>
    I_Battler Caster { get; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    I_Combat Arena { get; }

    bool CanThaw { get; }

    bool IsMeta { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Called when the move is used
    /// </summary>
    public void OnUse()
    {
        OnUse(this);
    }

    /// <summary>
    /// Get the targets of the move
    /// </summary>
    /// <returns>All targets to be hit by the move</returns>
    [Pure]
    public IEnumerable<I_Battler> GetTargets()
    {
        return GetTargets(this);
    }

    /// <summary>
    /// Activate pre-usage logic for a target
    /// </summary>
    /// <param name="target">The target to use</param>
    public void DoTarget(I_Battler target)
    {
        DoTarget(this, target);
    }

    /// <summary>
    /// Checks whether the move hits a target
    /// </summary>
    /// <param name="target">The target to check for</param>
    /// <returns>If the move hits, true, else false</returns>
    [Pure]
    public bool AccuracyCheck(I_Battler target)
    {
        return AccuracyCheck(this, target);
    }

    /// <summary>
    /// Execute the action of the move unto the target
    /// </summary>
    /// <param name="target">The target to use</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if CreateInfo is incorrectly overriden
    /// </exception>
    public void DoAction(I_Battler target)
    {
        DoAction(this, target);
    }

    /// <summary>
    /// Return the Info object
    /// </summary>
    /// <returns>Either a DamageInfo or an HealingInfo</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if a status move does not override this
    /// </exception>
    [Pure]
    public object CreateInfo()
    {
        return CreateInfo(this);
    }

    /// <summary>
    /// Called whenever the attack miss a target
    /// </summary>
    /// <param name="target">The target that the attack just missed</param>
    public void OnMiss(I_Battler target)
    {
        OnMiss(this, target);
    }

    /// <summary>
    /// Called whenever a move successfully damage its target
    /// </summary>
    /// <param name="target">The target that was stricken</param>
    public void DoBonusEffects(I_Battler target) { }

    /// <summary>
    /// Called before the queue is sorted
    /// </summary>
    /// <param name="ev">The event that uses this move</param>
    public void PreAction(MoveEvent ev) { }

    /// <summary>
    /// String representation of the basic status of the battler
    /// </summary>
    [Pure]
    public string GetQuickStatus();

    /// <summary>
    /// String representation of most information about the battler
    /// </summary>
    [Pure]
    public string GetFullStatus();
    #endregion

    #region Methods - Static
    /// <summary>
    /// Called when the move is used
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    public static void OnUse(I_Skill skill)
    {
        // Active the caster's ability
        bool cancel = skill.Caster.Ability.BeforeAttack(skill);
        cancel = skill.Caster.StatusEffects
                      .Aggregate(cancel, (current, effect) => current || effect.BeforeAttack(skill));

        // Cancel the attack if needed
        if (cancel)
            return;

        // For each target, if the move hits, deal damage
        foreach (I_Battler target in skill.GetTargets())
        {
            skill.DoTarget(target);
        }

        skill.Caster.Ability.AfterAttack(skill);
    }

    /// <summary>
    /// Get the targets of the move
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <returns>All targets to be hit by the move</returns>
    [Pure]
    public static IEnumerable<I_Battler> GetTargets(I_Skill skill)
    {
        return skill.Arena.Players
                    .Where(player => player != skill.Caster.Owner)
                    .Select(player => player.Active);
    }

    /// <summary>
    /// Activate pre-usage logic for a target
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <param name="target">The target to use</param>
    public static void DoTarget(I_Skill skill, I_Battler target)
    {
        bool hit = skill.AccuracyCheck(target);

        if (hit)
        {
            // Active the target's ability
            bool cancel = target.Ability.BeforeDefend(skill);
            cancel = target.StatusEffects
                           .Aggregate(cancel, (current, effect) => current || effect.BeforeDefend(skill));

            // Cancel the attack if needed
            if (cancel)
                return;

            skill.DoAction(target);

            // Active the target's ability
            target.Ability.AfterDefend(skill);
        }
        else
        {
            // If the skill miss, activate potential special effects
            skill.OnMiss(target);
        }
    }

    /// <summary>
    /// Checks whether the move hits a target
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <param name="target">The target to check for</param>
    /// <returns>If the move hits, true, else false</returns>
    [Pure]
    public static bool AccuracyCheck(I_Skill skill, I_Battler target)
    {
        if (skill.Accuracy == null)
            return true;

        return (skill.Accuracy ?? 100) >= Program.Rnd.Next(1, 100);
    }

    /// <summary>
    /// Execute the action of the move unto the target
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <param name="target">The target to use</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if CreateInfo is incorrectly overriden
    /// </exception>
    public static void DoAction(I_Skill skill, I_Battler target)
    {
        // Create the damage / healing and execute it
        bool success =
            skill.CreateInfo() switch
            {
                DamageInfo dmgInfo   => InteractionHandler.DoDamage(dmgInfo, skill.Caster, target),
                HealingInfo healInfo => InteractionHandler.DoHealing(healInfo, target),

                _ => throw new InvalidOperationException(),
            };

        // Do bonus effects, or inform the player if it failed
        if (success)
            skill.DoBonusEffects(target);
        else
            Console.WriteLine("But it failed");
    }

    /// <summary>
    /// Return the Info object
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown whenever a status move does not override this
    /// </exception>
    [Pure]
    public static object CreateInfo(I_Skill skill)
    {
        return skill.Class switch
               {
                   MoveClass.Physical => DamageInfo.CreatePhysical(skill.Power ?? 0, skill.Type),
                   MoveClass.Special  => DamageInfo.CreateSpecial(skill.Power ?? 0, skill.Type),

                   _ => throw new InvalidOperationException(),
               };
    }

    /// <summary>
    /// Called whenever the attack miss a target
    /// </summary>
    /// <param name="skill">The skill to act upon</param>
    /// <param name="target">The target that the attack just missed</param>
    public static void OnMiss(I_Skill skill, I_Battler target)
    {
        Console.WriteLine($"{skill.Caster}'s {skill.Name} missed {target}\n");
    }
    #endregion
}