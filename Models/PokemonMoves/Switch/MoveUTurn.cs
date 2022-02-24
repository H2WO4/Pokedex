using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveUTurn : PokemonMove
	{
		public MoveUTurn() : base(
			"U-Turn",
			MoveClass.Physical,
			70, 100, // Pow & Acc
			20, 0, // PP & Priority
			TypeNormal.Singleton
		) {}
		
		public override void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
			bool success = target.ReceiveDamage(owner, caster, this, this._type, context);
			if (!success)
				Console.WriteLine("But it failed");
			else
			{
				var ev = new SwitchInputEvent(origin, context);
				context.AddToTop(ev);
			}
		}
    }
}