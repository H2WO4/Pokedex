using System.Text;
using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;


namespace Pokedex.Models
{
	/// <summary>
	/// A selectable Pokemon move
	/// </summary>
	public abstract class PokeMove : I_PokeMove
	{
		#region Variables
		protected I_Battler? _caster;
		#endregion

		#region Properties
		public string Name { get; }

		public int? Power { get; protected set; }

		public MoveClass Class { get; }

		public int? Accuracy { get; }

		public int MaxPP { get; }

		public int PP { get; protected set; }

		public int Priority { get; protected set; }

		public PokeType Type { get; }

        public I_Battler Caster
		{
			get => this._caster ?? throw new InvalidOperationException();
			set => this._caster = value;
		}
		
		public I_Combat Arena => this.Caster.Arena;

        #endregion

        #region Constructors
        public PokeMove(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		)
		{
			if (name != "")
				this.Name = name;
			else throw new ArgumentException("Name cannot be empty");

			this.Class = class_;
			this.Power = power;
			this.Accuracy = accuracy;
			this.MaxPP = maxPp;
			this.PP = maxPp;
			this.Priority = priority;
			this.Type = type;
		}
		#endregion

		#region Methods
		public virtual void OnUse()
		{
			// Select targets
			var targets = this.GetTargets();

			// If it hits, deal damage, and check if fainted
			foreach (var target in targets)
			{
				var hit = this.AccuracyCheck(target);

				if (hit)
					this.DoAction(target);
				else
					Console.WriteLine($"{this.Caster.Name}'s {this.Name} missed {target.Name}\n");
			}
		}

		/// <summary>
		/// Get the targets of the move
		/// </summary>
		/// <returns>All targets to be hit by the move</returns>
		protected virtual List<I_Battler> GetTargets()
			=> this.Arena.Players
				.Where(player => player != this.Caster.Owner)
				.Select(player => player.Active)
				.ToList();

		/// <summary>
		/// Checks whether the move hits a target
		/// </summary>
		/// <param name="target">The target to check for</param>
		/// <returns>If the move hits, true, else false</returns>
		protected virtual bool AccuracyCheck(I_Battler target)
		{
			if (this.Accuracy == null)
				return true;

			return (this.Accuracy ?? 100) >= Program.rnd.Next(1, 100);
		}

		/// <summary>
		/// Execute the action of the move unto the target
		/// </summary>
		/// <param name="target">The target to use</param>
		protected virtual void DoAction(I_Battler target)
		{
			DamageClass dmgClass = this.Class == MoveClass.Physical
									? DamageClass.Physical
									: DamageClass.Special;

			double power = this.Power ?? 0;

			// ? Implement BeforeAttack
			// Code

			// Apply STAB
			if (this.Caster.Types.Contains(this.Type))
				power *= 1.5;


			bool success = target.ReceiveDamage(this.Caster, new DamageInfo(dmgClass, this.Power ?? 0, this.Type));
			if (!success)
				Console.WriteLine("But it failed");
		}

		public virtual void PreAction(MoveEvent event_) { }

		public string GetQuickStatus()
			=> $"{this.Name} - {this.PP}/{this.MaxPP} \x1b[38;2;144;238;144mPP\x1b[0m";

		public string GetFullStatus()
		{
			var status = new StringBuilder();
			var classColor = this.Class == MoveClass.Physical ? "\x1b[38;2;245;78;10m"
							: this.Class == MoveClass.Special ? "\x1b[38;2;38;117;244m"
							: "\x1b[38;2;90;99;123m";

			// Add the name
			status.Append($"\x1b[1m{this.Name,-12}\x1b[0m   ");
			// Add the class and type
			status.AppendLine($"{classColor}{this.Class}\x1b[0m-{this.Type}");
			// Add the Power, '---' if null
			status.Append($"\x1b[38;2;219;112;147mPower\x1b[0m: {this.Power?.ToString() ?? "---",4}      ");
			// Add the Accuracy, '---' if null
			status.AppendLine($"\x1b[38;2;173;216;230mAccuracy\x1b[0m: {this.Accuracy?.ToString("#'%'") ?? "---",4}");
			// Add the PP
			status.Append($"\x1b[38;2;144;238;144mPP\x1b[0m:   {this.PP,2}/{this.MaxPP,2}      ");
			// Add the Priority, with sign if positive, but not if 0
			status.AppendLine($"\x1b[38;2;255;165;0mPriority\x1b[0m:  {this.Priority,3:+#;-#;0}");

			return status.ToString();
		}
        #endregion
    }
}