using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	public abstract class PokemonMove : I_PokemonMove
	{
		# region Variables
		protected string _name;
		protected MoveClass _class;
		protected int? _power;
		protected int? _accuracy;
		protected int _maxPp;
		protected int _pp;
		protected int _priority;
		protected PokemonType _type;
		# endregion

		# region Properties
		// Values
		public string Name { get => this._name; }
		public int? Power { get => this._power; }
		public MoveClass Class { get => this._class; }
		public int? Accuracy { get => this._accuracy; }
		public int MaxPP { get => this._maxPp; }
		public int PP { get => this._pp; }
		public int Priority { get => this._priority; }
		public PokemonType Type { get => this._type; }

		// Others
		public string QuickStatus { get => $"{this.Name} - {this._pp}/{this._maxPp} PP"; }
		public string FullStatus { get => string.Join('\n', new string[]{
			$"{this._name, -12}   {this._class}-{this._type.Name}",
			$"Power: {this._power, 4}    Accuracy: {this._accuracy, 3}%",
			$"PP:   {this._pp, 2}/{this._maxPp, 2}    Priority: {this._priority, 2:+#;-#;0}",
		}); }
		# endregion

		# region Constructors
		public PokemonMove(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokemonType type
		)
		{
			if (name != "")
				this._name = name;
			else throw new ArgumentException("Name cannot be empty");

			this._class = class_;
			this._power = power;
			this._accuracy = accuracy;
			this._maxPp = maxPp;
			this._pp = maxPp;
			this._priority = priority;
			this._type = type;
		}
		# endregion

		# region Methods
		public virtual void OnUse(Pokemon caster, Player origin, CombatInstance context)
		{
			// Select targets
			var targets = this.GetTargets(caster, origin, context);

			// Accuracy check
			var hits = targets
				.Select(target => this.AccuracyCheck(target.pokemon, target.player, caster, origin, context));
			
			// If it hits, deal damage, and check if fainted
			foreach (var pair in targets.Zip(hits))
			{
				var target = pair.First;
				var hit = pair.Second;

				if (hit)
					this.DoAction(target.pokemon, target.player, caster, origin, context);
				else
					Console.WriteLine($"{caster.Nickname}'s {this.Name} missed {target.pokemon.Nickname}\n");
			}
		}

        public virtual bool AccuracyCheck(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
        {
            var rnd = Program.rnd;
			return (this._accuracy ?? 100) >= rnd.Next(1, 100);
        }

        public virtual List<(Player player, Pokemon pokemon)> GetTargets(Pokemon caster, Player origin, CombatInstance context)
        {
            var enemy = context.PlayerA == origin
						? context.PlayerB
						: context.PlayerA;
			
			return new List<(Player, Pokemon)>()
			{
				(enemy, enemy.Active)
			};
        }

        public virtual void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
            bool success = target.ReceiveDamage(owner, caster, this, this._type, context);
			if (!success)
				Console.WriteLine("But it failed");
		}

		public virtual void PreAction(MoveEvent event_, CombatInstance context) {}
        #endregion
    }
}