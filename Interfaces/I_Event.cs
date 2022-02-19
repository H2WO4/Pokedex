namespace Pokedex.Interfaces
{
	public interface I_Event
	{
		# region Properties
		int Priority { get; }
		int Speed { get; }
		# endregion

		# region Methods
		public void Update();
		# endregion
	}
}