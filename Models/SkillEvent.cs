using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public class SkillEvent : I_Event
	{
		# region Variables
		private PokemonSkill _skill;
		private List<I_Event> _eventQueue;
		#endregion

		#region Properties
		public int Priority { get => this._skill.Priority; }
		# endregion

		# region Constructors
		public SkillEvent(PokemonSkill skill, ref List<I_Event> eventQueue)
		{
			this._skill = skill;
			this._eventQueue = eventQueue;
		}
		# endregion

		# region Methods
		public void update()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}