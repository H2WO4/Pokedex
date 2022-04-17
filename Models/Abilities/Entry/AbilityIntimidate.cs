using Pokedex.Enums;


namespace Pokedex.Models.Abilities;

public class AbilityIntimidate : Models.Ability
{
	#region Constructors
	public AbilityIntimidate(Pokemon origin)
		: base("Intimidate", origin) { }
	#endregion

	#region Methods
	public override void OnEnter()
	{
		Announce();
		Origin.Arena.Players
			  .Where(player => player != Origin.Owner)
			  .Select(player => player.Active)
			  .OfType<Pokemon>()
			  .ToList()
			  .ForEach(poke => poke.ChangeStatBonus(Stat.Atk, -1));
	}
	#endregion
}