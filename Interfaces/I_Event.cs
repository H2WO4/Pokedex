namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can be used in event queues
/// </summary>
public interface I_Event
{
	#region Properties
	/// <summary>
	/// Main variable used to sort the queue
	/// </summary>
	public int Priority { get; }
		
	/// <summary>
	/// Secondary variable used to sort the queue
	/// </summary>
	public int Speed { get; }

	/// <summary>
	/// In which combat the fight happens in
	/// </summary>
	public I_Combat Context { get; }
	#endregion

	#region Methods
	/// <summary>
	/// Called during the queue's execution
	/// </summary>
	public void Update();

	/// <summary>
	/// Called before the queue is sorted
	/// </summary>
	/// <remarks>Designed for actions that could change the event's priority</remarks>
	public void PreUpdate();
	#endregion
}