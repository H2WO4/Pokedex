using Pokedex.Interfaces;

namespace Pokedex.Models
{
    public class Player : I_Player
    {
        # region Variables
        private string _name;

        private Pokemon _active;
        private List<Pokemon> _bench;

        private CombatInstance _context;
        # endregion

        # region Properties
        public string Name { get => this._name; }

        public Pokemon Active { get => this._active; }
        public List<Pokemon> Bench { get => this._bench; }
        # endregion

        # region Constructors
        public Player(
            string name,
            Pokemon active,
            List<Pokemon> bench,
            CombatInstance context
        )
        {
            this._name = name;

            this._active = active;

            if (bench.Count <= 5)
                this._bench = bench;
            else throw new ArgumentException("Bench must have 5 or less Pokemon.");

            this._context = context;
        }
        # endregion

        # region Methods
        public void PlayTurn()
        {
            bool endTurn = false;

            while (!endTurn)
            {
                // Read the command
                string[] action = Console.ReadLine()!
                    .ToLower()
                    .Split(' ');
                
                // Depending on the first word
                switch (action[0])
                {
                    case "status":
                        this.StatusAction(action);
                    break;

                    case "move":
                        this.MoveAction(action, out endTurn);
                    break;
                    
                    case "switch":
                        this.SwitchAction(action, out endTurn);
                    break;

                    default:
                        Console.WriteLine("Invalid command");
                    break;
                }
            }
        }

        private void StatusAction(string[] action)
        {
            // Check if 2 args
            if (action.Count() != 2)
            {
                Console.WriteLine("Invalid number of arguments");
                return;
            }

            Console.WriteLine(this._active.StatusAlly + '\n');
            if (this._context.PlayerA == this)
                Console.WriteLine(this._context.PlayerB.Active.StatusOpponent + '\n');
            else
                Console.WriteLine(this._context.PlayerA.Active.StatusOpponent + '\n');
        }

        private void MoveAction(string[] action, out bool endTurn)
        {
            endTurn = false;

            // Check if 2 args
            if (action.Count() != 2)
            {
                Console.WriteLine("Invalid number of arguments");
                return;
            }

            int moveNum;
            // Check if 2nd arg is a number
            if (!Int32.TryParse(action[1], out moveNum))
            {
                Console.WriteLine("Second argument must be a number");
                return;
            }

            // Check if 2nd arg within 1-4
            if (moveNum < 1 || moveNum > 4)
            {
                Console.WriteLine("Invalid move number");
                return;
            }

            // Fetch the move
            PokemonMove? move = this._active.Moves[moveNum-1];
            // Check if a move is in that slot
            if (move == null)
            {
                Console.WriteLine("No move is in that slot");
                return;
            }

            // Create the event
            var ev = new MoveEvent
            (
                this._active, this,
                move, this._context
            );
            // Add it to the queue
            this._context.AppendEvent(ev);

            // Conclude the player's turn
            endTurn = true;
        }
        
        private void SwitchAction(string[] action, out bool endTurn)
        {
            endTurn = false;

            // Check if 2 args
            if (action.Count() != 2)
            {
                Console.WriteLine("Invalid number of arguments");
                return;
            }

            int pokeNum;
            // Check if 2nd arg is a number
            if (!Int32.TryParse(action[1], out pokeNum))
            {
                Console.WriteLine("Second argument must be a number");
                return;
            }

            // Check if 2nd arg within bounds
            if (pokeNum < 1 || pokeNum > this._bench.Count)
            {
                Console.WriteLine("Invalid move number");
                return;
            }

            // Create the event
            var ev = new SwitchEvent(
                this, this._bench[pokeNum-1],
                this._context
            );
            // Add it to the queue
            this._context.AppendEvent(ev);

            // Conclude the player's turn
            endTurn = true;
        }

        # endregion
    }
}