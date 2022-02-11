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
            while (true)
            {
                string[] action = Console.ReadLine()!
                    .ToLower()
                    .Split(' ');
                
                switch (action[0])
                {
                    case "status":
                    Console.WriteLine(this._active.StatusAlly + '\n');
                    if (this._context.PlayerA == this)
                        Console.WriteLine(this._context.PlayerB.Active.StatusOpponent + '\n');
                    else
                        Console.WriteLine(this._context.PlayerA.Active.StatusOpponent + '\n');
                    break;

                    case "move":
                    if (action.Count() == 2)
                    {
                        var move = this._active.Moves
                            .Find(x => x.Name.ToLower() == action[1]);
                        
                        if (move != null)
                        {
                            var ev = new MoveEvent(
                                this._active, this,
                                move, this._context
                            );
                            this._context.AppendEvent(ev);
                            return;
                        }
                        else Console.WriteLine("Invalid move");
                    }
                    else Console.WriteLine("Invalid number of arguments");
                    break;
                    
                    case "switch":
                    if (action.Count() == 2)
                    {
                        var poke = this._bench
                            .Find(x => x.Name.ToLower() == action[1]);

                        if (poke != null)
                        {
                            var ev = new SwitchEvent(
                                this, poke,
                                this._context
                            );
                            this._context.AppendEvent(ev);
                            return;
                        }
                    }
                    else Console.WriteLine("Invalid number of arguments");
                    break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
        # endregion
    }
}