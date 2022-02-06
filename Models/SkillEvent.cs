using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public class SkillEvent : I_Event
	{
		# region Variables
		private PokemonSkill _skill;
		private CombatInstance _context;
		#endregion

		#region Properties
		public int Priority { get => this._skill.Priority; }
		# endregion

		# region Constructors
		public SkillEvent
		(
			PokemonSkill skill,
			CombatInstance context
		)
		{
			this._skill = skill;
			this._context = context;
		}
		# endregion

		# region Methods
		public void Update()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}