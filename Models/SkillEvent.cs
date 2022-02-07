using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public class SkillEvent : I_Event
	{
		# region Variables
		protected Pokemon _origin;
		protected Team _originTeam;
		protected PokemonMove _skill;
		protected CombatInstance _context;
		#endregion

		#region Properties
		public Team OriginTeam { get => this._originTeam; }
		public int Priority { get => this._skill.Priority; }
		# endregion

		# region Constructors
		public SkillEvent
		(
			Pokemon origin,
			Team originTeam,
			PokemonMove skill,
			CombatInstance context
		)
		{
			this._origin = origin;
			this._originTeam = originTeam;
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