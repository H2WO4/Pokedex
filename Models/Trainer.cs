using Pokedex.Interfaces;
using Pokedex.Models.Events;

namespace Pokedex.Models;

/// <summary>
/// Implements an human-controlled Player
/// </summary>
public class Trainer : I_Player
{
    #region Variables
    private int _activeIndex;
    #endregion

    #region Properties
    public string Name { get; }

    public I_Battler Active
        => Team[_activeIndex];

    public I_Battler[] Team { get; }

    public I_Combat Arena { get; }
    #endregion

    #region Constructors
    public Trainer(
        string name,
        I_Battler[] team,
        I_Combat arena
    )
    {
        Name = name;

        _activeIndex = 0;

        if (team.Any()
         && team.Length <= 6)
            Team = team;
        else throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

        Team
           .ToList()
           .ForEach(poke => poke.Owner = this);

        Arena = arena;
    }
    #endregion

    #region Methods
    public void PlayTurn()
    {
        var endTurn = false;

        Active.Ability.OnTurnStart();

        // Until the player entered a command ending their turn
        // Or stdin is empty
        while (!endTurn)
        {
            // Read the command, and split it into words
            string[] action = Console.ReadLine()!
                                     .ToLower()
                                     .Split(' ');

            InterpretCommand(action, out endTurn);

            Console.WriteLine();
        }

        Active.Ability.OnTurnEnd();
    }

    private void InterpretCommand(string[] action, out bool endTurn)
    {
        switch (action)
        {
            case ["status", string argWhat,  "full" or "detailed"]:
                StatusCommand(argWhat, true);
                break;

            case ["status", string argWhat]:
                StatusCommand(argWhat, false);
                break;

            case ["use", string argWhich]:
                MoveCommand(argWhich, out endTurn);
                break;

            case ["switch", string argWhich]:
                SwitchCommand(argWhich, out endTurn);
                break;

            case ["help"]:
                Console.WriteLine("- status [self | enemy | bench | moves] <full>");
                Console.WriteLine("- use [#move]");
                Console.WriteLine("- switch [#pokemon]");
                Console.WriteLine();
                break;

            case [""]:
                continue;

            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }

    /// <summary>
    /// Sub-method handling the <c>status ...</c> commands
    /// </summary>
    /// <param name="argWhat">The command parameter inputted by the player</param>
    /// <param name="detail">Whether full details are asked</param>
    private void StatusCommand(string argWhat, bool detail)
    {
        // Depending on the second word
        switch (argWhat)
        {
            case "active" or "self":
                SelfStatus(detail);
                break;

            case "enemy" or "other" when !detail:
                OtherStatus();
                break;

            case "bench":
                BenchStatus(detail);
                break;

            case "move" or "moves":
                MoveStatus(detail);
                break;

            default:
                Console.WriteLine("Invalid parameter");
                break;
        }
    }

    private void SelfStatus(bool showDetail)
    {
        Console.WriteLine(showDetail
                              ? Active.GetFullStatus()
                              : Active.GetQuickStatus());
    }

    private void BenchStatus(bool showDetail)
    {
        for (var i = 0; i < Team.Length; i++)
        {
            if (i == _activeIndex)
                continue;

            string pokeStatus = showDetail 
                                    ? Team[i].GetFullStatus()
                                    : Team[i].GetQuickStatus();
            Console.WriteLine($"{i + 1} {pokeStatus}");
        }

        if (Team.Length == 1)
            Console.WriteLine("No pokemon on the bench");
    }

    private void OtherStatus()
    {
        Arena.Players
             .Where(player => player != this)
             .Select(player => player.Active)
             .ToList()
             .ForEach(poke => Console.WriteLine(poke.GetQuickStatus()));
    }

    private void MoveStatus(bool showDetail)
    {
        for (var i = 0; i < 4; i++)
        {
            string moveStatus = showDetail
                                    ? Active.Moves[i]?.GetFullStatus() ?? "---"
                                    : Active.Moves[i]?.GetQuickStatus() ?? "---";
            Console.WriteLine($"{i + 1} {moveStatus}");
        }
    }

    /// <summary>
    /// Sub-method handling the <c>move ...</c> commands
    /// </summary>
    /// <param name="argWhich">The command parameters inputted by the player</param>
    /// <param name="endTurn">Set to true if this action ends the turn</param>
    private void MoveCommand(string argWhich, out bool endTurn)
    {
        endTurn = false;

        int moveNum;
        // Check if arg is a number
        if (!int.TryParse(argWhich, out moveNum))
        {
            Console.WriteLine("Second argument must be a number");
            return;
        }

        // Check if 2nd arg within 1-4
        if (moveNum is < 1 or > 4)
        {
            Console.WriteLine("Invalid move number");
            return;
        }

        // Fetch the move
        PokeMove? move = Active.Moves[moveNum - 1];
        // Check if a move is in that slot
        if (move is null)
        {
            Console.WriteLine("No move is in that slot");
            return;
        }

        // Create the event
        var ev = new MoveEvent(Active,
                               move, Arena);
        // Add it to the queue
        Arena.AddToBottom(ev);

        // Conclude the player's turn
        endTurn = true;
    }

    /// <summary>
    /// Sub-method handling the <c>switch ...</c> commands
    /// </summary>
    /// <param name="argWhich">The command parameters inputted by the player</param>
    /// <param name="endTurn">Set to true if this action ends the turn</param>
    private void SwitchCommand(string argWhich, out bool endTurn)
    {
        endTurn = false;

        int pokeNum;
        // Check if 2nd arg is a number
        if (!int.TryParse(argWhich, out pokeNum))
        {
            Console.WriteLine("Second argument must be a number");
            return;
        }

        pokeNum--; // Change from 1-based index to 0-based

        // Check if 2nd arg within bounds
        if (pokeNum < 1
         || pokeNum > Team.Length)
        {
            Console.WriteLine("Invalid pokemon number");
            return;
        }

        // Check if 2nd arg is not already active pokemon
        if (pokeNum == _activeIndex)
        {
            Console.WriteLine("This pokemon is already on the field");
            return;
        }

        if (Team[pokeNum]
               .CurrHP
         == 0)
        {
            Console.WriteLine("This pokemon is K.O.");
            return;
        }

        // Create the event
        var ev = new SwitchEvent(this, pokeNum,
                                 Arena);
        // Add it to the queue
        Arena.AddToBottom(ev);

        // Conclude the player's turn
        endTurn = true;
    }

    public void ChangeActive(int index)
    {
        Console.WriteLine($"{Name} takes out {Active}");
        Active.Ability.OnExit();
        Console.WriteLine();

        _activeIndex = index;

        Console.WriteLine($"{Name} sends out {Active}");
        Active.Ability.OnEnter();
        Console.WriteLine();
    }

    public void AskActiveChange()
    {
        Console.WriteLine("Choose a pokemon to send");
        Console.WriteLine();

        // Print the available pokemons
        Team.Select((poke, i) => (poke, i))
            .Where(pair => pair.poke != Active && pair.poke.CurrHP > 0)
            .ToList()
            .ForEach(pair => Console.WriteLine($"{pair.i + 1}: {pair.poke.GetQuickStatus()}"));

        Console.WriteLine();

        // Until a valid pokemon is chosen
        var pokeChosen = false;
        while (!pokeChosen)
        {
            // Take input
            string input = Console.ReadLine()!;
            int    pokeNum;

            // Check if arg is a number
            if (!int.TryParse(input, out pokeNum))
            {
                Console.WriteLine("Second argument must be a number");
                continue;
            }

            pokeNum--; // Change from 1-based index to 0-based

            // Check if arg within bounds
            if (pokeNum < 1
             || pokeNum > Team.Length)
            {
                Console.WriteLine("Invalid pokemon number");
                continue;
            }

            // Check if pokemon is not fainted
            if (Team[pokeNum].CurrHP == 0)
            {
                Console.WriteLine("This pokemon is K.O.");
                continue;
            }

            ChangeActive(pokeNum);
            pokeChosen = true;
        }
    }
    #endregion
}