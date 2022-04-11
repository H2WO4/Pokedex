using Pokedex.Enums;

namespace Pokedex.Models.Abilities
{
	public class AbilityIntimidate : Ability
	{
		#region Constructors
		public AbilityIntimidate()
			: base("Intimidate")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			this.Announce();
			this.Origin.Arena.Players
				.Where(player => player != this.Origin.Owner)
				.Select(player => player.Active)
				.OfType<Pokemon>()
				.ToList()
				.ForEach(poke => poke.ChangeStatBonus(Stat.Atk, -1));
		}
		#endregion
	}
}