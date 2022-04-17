using Pokedex.Interfaces;


namespace Pokedex.Models.Events;

public class SwitchEvent : I_Event
{
	#region Constructors
	public SwitchEvent
	(
		Trainer originPlayer,
		int target,
		I_Combat context
	)
	{
		Origin  = originPlayer;
		Target  = target;
		Context = context;
	}
	#endregion

	#region Properties
	public int Priority => 6;

	public int Speed => 0;

	/// <summary>
	///     The player who initiated the switch
	/// </summary>
	public Trainer Origin { get; }

	/// <summary>
	///     The Pokemon index to switch into
	/// </summary>
	/// <value></value>
	private int Target { get; }

	/// <summary>
	///     In which combat the fight happens in
	/// </summary>
	public I_Combat Context { get; }
	#endregion

	#region Methods
	public void Update()
	{
		if (Origin.Active.CurrHP == 0)
			return;

		Origin.ChangeActive(Target);
	}

	public void PreUpdate() { }
	#endregion
}