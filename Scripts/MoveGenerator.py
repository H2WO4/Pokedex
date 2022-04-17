# Imports
import json

# Load the json file
data = {}
with open("Data/moves.json", encoding="utf-8") as f:
    data = json.load(f)

moveName: str
# For each move in the list
while moveName := input():
    move = data[moveName]

    # Find the name to use in file names
    moveName: str = move["name"].replace('-', ' ').title()
    moveNameNoSpace: str = moveName.replace(' ', '')

    # Create the PokemonMove class, by opening a file
    with open(f"Models/PokemonMoves/Move{moveNameNoSpace}.cs", 'w', encoding="utf-8") as f:
        # Load the template code
        outfile = f"""

using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{{
	public class Move{moveNameNoSpace} : PokeMove
	{{
		public Move{moveNameNoSpace}() : base(
			"{moveName}",
			MoveClass.{move["damage_class"].title()},
			{move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
			{move["pp"]}, {move["priority"]}, // PP & Priority
			Type{move["type"].title()}.Singleton
		)
		{{ }}
	}}
}}

"""[2:-2]
        # ↑ Delete the first two and last two newlines, here for readability

        # Write the code to the file
        f.write(outfile)
