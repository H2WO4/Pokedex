using Pokedex.Interfaces;

namespace Pokedex.Models.Events;

public class MoveEvent : I_Event
{
	#region Properties
	public int Priority { get; set; }
	public int Speed { get; set; }

	/// <summary>
	/// The Pokemon who used the move
	/// </summary>
	public I_Battler Caster { get; }

	/// <summary>
	/// The move used
	/// </summary>
	public PokeMove Move { get; }

	/// <summary>
	/// In which combat the fight happens in
	/// </summary>
	private I_Combat Context { get; }
	#endregion

	#region Constructors
	public MoveEvent
	(
		I_Battler caster,
		Trainer origin,
		PokeMove move,
		I_Combat context
	)
	{
		Caster = caster;
		Move = move;
		Context = context;

		Priority = move.Priority;
		Speed = caster.Spd();
	}
	#endregion

	#region Methods
	public void Update()
	{
		if (Caster.CurrHP == 0)
			return;

		// Print move usage
		Console.WriteLine("" + $"{Caster.Name} uses {Move.Name}" + "");
		Move.OnUse();
	}

	public void PreUpdate() => Move.PreAction(this);
	#endregion
}