# Imports
import json
import os

# Load the json file
data = {}
with open("Data\\moves.json", encoding="utf-8") as f:
	data = json.load(f)

# Give every move that should be generated
nameList = ["pound", "karate-chop", "mega-punch"]
nameList.extend(["fire-punch", "ice-punch", "thunder-punch", "shadow-punch"]) # The ***-punch series

nameList.extend(["guillotine"]) # The OHKO series

# For each move in the list
for move in [data[name] for name in nameList]:
	# Find the name to use in file names
	moveName: str = move["name"].title()
	moveNameNoSpace: str = ''.join([c for c in moveName if c not in (' ', '-')])

	# If the file alreay exist, don't touch it
	if (os.path.isfile(f"Models\\PokemonMoves\\Move{moveNameNoSpace}.cs")): continue

	# Create the PokemonMove class, by opening a file
	with open(f"Models\\PokemonMoves\\Move{moveNameNoSpace}.cs", 'w', encoding="utf-8") as f:
		# Load the template code
		outfile = f"""

using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{{
	public class Move{moveNameNoSpace} : PokemonMove
	{{
		public Move{moveNameNoSpace}() : base(
			"{moveName}",
			MoveClass.{move["damage_class"].title()},
			{move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
			{move["pp"]}, {move["priority"]}, // PP & Priority
			Type{move["type"].title()}.Singleton
		) {{}}
	}}
}}

"""[2:-2]
		# ↑ Delete the first two and last two newlines, here for readability

		# Write the code to the file
		f.write(outfile)
