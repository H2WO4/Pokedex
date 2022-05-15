using System.Reflection;
using System.Text;

using Pokedex.Enums;
using Pokedex.Interfaces;


namespace Pokedex.Models;

/// <summary>
/// A selectable Pokemon move
/// </summary>
public abstract class PokeMove : I_Skill
{
    #region Variables
    private I_Battler? _caster;
    #endregion

    #region Class Variables
    protected static readonly IEnumerable<PokeMove> AllMoves =
        Assembly.GetAssembly(typeof(PokeMove))!
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(PokeMove))
                            && type.IsClass
                            && type.IsAbstract is false)
                .Select(type => (PokeMove) Activator.CreateInstance(type)!);
    #endregion

    #region Properties
    public string Name { get; }

    public int? Power { get; set; }

    public MoveClass Class { get; }

    public int? Accuracy { get; set; }

    public int MaxPP { get; }

    public int PP { get; protected set; }

    public int Priority { get; protected set; }

    public PokeType Type { get; set; }

    public I_Battler Caster { get => _caster ?? throw new InvalidOperationException(); set => _caster = value; }

    public I_Combat Arena
        => Caster.Arena;

    public bool CanThaw
        => false;

    public virtual bool IsMeta
        => false;
    #endregion

    #region Constructors
    protected PokeMove(
        string name,
        MoveClass @class,
        int? power,
        int? accuracy,
        int maxPp,
        int priority,
        PokeType type
    )
    {
        if (name != "")
            Name = name;
        else throw new ArgumentException("Name cannot be empty");

        Class    = @class;
        Power    = power;
        Accuracy = accuracy;
        MaxPP    = maxPp;
        PP       = maxPp;
        Priority = priority;
        Type     = type;
    }
    #endregion

    #region Methods
    public string GetQuickStatus()
        => $"{Name} - {PP}/{MaxPP} PP";

    public string GetFullStatus()
    {
        var status = new StringBuilder();

        // Add the name
        status.Append($"{Name,-12}   ");
        // Add the class and type
        status.AppendLine($"{Class}-{Type}");
        // Add the Power, '---' if null
        status.Append($"Power: {Power?.ToString() ?? "---",4}      ");
        // Add the Accuracy, '---' if null
        status.AppendLine($"Accuracy: {Accuracy?.ToString("#'%'") ?? "---",4}");
        // Add the PP
        status.Append($"PP:   {PP,2}/{MaxPP,2}      ");
        // Add the Priority, with sign if positive, but not if 0
        status.AppendLine($"Priority:  {Priority,3:+#;-#;0}");

        return status.ToString();
    }

    public override string ToString()
        => Name;
    #endregion
}