using System.Diagnostics.CodeAnalysis;
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

    public I_Battler[ ] Team { get; }

    [NotNull]
    public I_Combat? Arena { get; set; }
    #endregion

    #region Constructors
    public Trainer(
        string       name,
        I_Battler[ ] team
    )
    {
        Name = name;

        _activeIndex = 0;

        if (team.Length is >= 1 and <= 6)
            Team = team;
        else
            throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

        Team.ToList()
            .ForEach(poke => poke.Owner = this);
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
            string[ ] action = Console.ReadLine()!
                                      .ToLower()
                                      .Split(' ');

            InterpretCommand(action, out endTurn);

            Console.WriteLine();
        }

        Active.Ability.OnTurnEnd();
    }

    private void InterpretCommand(string[ ] action, out bool endTurn)
    {
        endTurn = false;
        switch (action.ElementAtOrDefault(0), action.ElementAtOrDefault(1), action.ElementAtOrDefault(2),
                action.ElementAtOrDefault(3))
        {
            case ("status", { } argWhat, "full" or "detailed", null):
                StatusCommand(argWhat, true);

                break;

            case ("status", { } argWhat, null, null):
                StatusCommand(argWhat, false);

                break;

            case ("use", { } argWhich, null, null):
                MoveCommand(argWhich, out endTurn);

                break;

            case ("switch", { } argWhich, null, null):
                SwitchCommand(argWhich, out endTurn);

                break;

            case ("help", null, null, null):
                Console.WriteLine("- status [self | enemy | bench | moves] <full>");
                Console.WriteLine("- use [#move]");
                Console.WriteLine("- switch [#pokemon]");
                Console.WriteLine();

                break;

            case ("", null, null, null):
                break;

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

    /// <summary>
    /// Sub-method handling the <c>status self ...</c> commands
    /// </summary>
    /// <param name="showDetail">Whether details should be shown</param>
    private void SelfStatus(bool showDetail)
    {
        Console.WriteLine(showDetail
                              ? Active.GetFullStatus()
                              : Active.GetQuickStatus());
    }

    /// <summary>
    /// Sub-method handling the <c>status bench ...</c> commands
    /// </summary>
    /// <param name="showDetail">Whether details should be shown</param>
    private void BenchStatus(bool showDetail)
    {
        for (var i = 0; i < Team.Length; i++)
        {
            if (i == _activeIndex)
                continue;

            string pokeStatus = showDetail
                                    ? Team[i]
                                       .GetFullStatus()
                                    : Team[i]
                                       .GetQuickStatus();

            Console.WriteLine($"{i + 1} {pokeStatus}");
        }

        if (Team.Length == 1)
            Console.WriteLine("No pokemon on the bench");
    }

    /// <summary>
    /// Sub-method handling the <c>status other</c> command
    /// </summary>
    private void OtherStatus()
    {
        Arena.Players
             .Where(player => player != this)
             .Select(player => player.Active)
             .ToList()
             .ForEach(poke => Console.WriteLine(poke.GetQuickStatus()));
    }

    /// <summary>
    /// Sub-method handling the <c>status move ...</c> commands
    /// </summary>
    /// <param name="showDetail">Whether details should be shown</param>
    private void MoveStatus(bool showDetail)
    {
        for (var i = 0; i < 4; i++)
        {
            string moveStatus = showDetail
                                    ? Active.Moves[i]
                                           ?.GetFullStatus()
                                   ?? "---"
                                    : Active.Moves[i]
                                           ?.GetQuickStatus()
                                   ?? "---";

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
        var ev = new MoveEvent(Active, move, Arena);
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

        if (ValidatePokeNum(argWhich, out pokeNum) is false)
            return;

        // Create the event
        var ev = new SwitchEvent(this, pokeNum,
                                 Arena);

        // Add it to the queue
        Arena.AddToBottom(ev);

        // Conclude the player's turn
        endTurn = true;
    }

    public void ChangeActive(int index, bool forced = false)
    {
        Console.WriteLine(forced
                              ? $"{Active} is forced out of combat!"
                              : $"{Name} takes out {Active}");

        Active.Ability.OnExit();
        Console.WriteLine();

        _activeIndex = index;

        Console.WriteLine(forced
                              ? $"{Name} sends out {Active}"
                              : $"{Active} is sent to combat!");

        Active.Ability.OnEnter();
        Console.WriteLine();
    }

    public void AskActiveChange()
    {
        Console.WriteLine("Choose a pokemon to send");
        Console.WriteLine();

        // Print the available pokemons
        var i = 1;
        IEnumerable<I_Battler> availablePokemons =
            Team.Where(poke => poke        != Active)
                .Where(poke => poke.CurrHP > 0);

        foreach (I_Battler poke in availablePokemons)
            Console.WriteLine($"{i++}: {poke.GetQuickStatus()}");

        Console.WriteLine();

        // Until a valid pokemon is chosen
        var pokeChosen = false;
        while (!pokeChosen)
        {
            // Take input
            string input = Console.ReadLine()!;
            int    pokeNum;

            if (ValidatePokeNum(input, out pokeNum) is false)
                continue;

            ChangeActive(pokeNum);
            pokeChosen = true;
        }
    }

    /// <summary>
    /// Check whether the given input is a valid Pokemon to switch to
    /// </summary>
    /// <param name="input">The text input</param>
    /// <param name="pokeNum">The numerical output</param>
    /// <returns>True if the valid is correct</returns>
    private bool ValidatePokeNum(string input, out int pokeNum)
    {
        // Check if arg is a number
        if (!int.TryParse(input, out pokeNum))
        {
            Console.WriteLine("Second argument must be a number");

            return false;
        }

        pokeNum--; // Change from 1-based index to 0-based

        // Check if arg within bounds
        if (pokeNum < 1
         || pokeNum > Team.Length)
        {
            Console.WriteLine("Invalid pokemon number");

            return false;
        }

        // Check if pokemon is not fainted
        if (Team[pokeNum]
               .CurrHP
         == 0)
        {
            Console.WriteLine("This pokemon is K.O.");

            return false;
        }

        return true;
    }
    #endregion
}