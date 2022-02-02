# Imports
import json
import os
import shutil

# Delete the old folder
shutil.rmtree("Models\\Pokemons")
os.mkdir("Models\\Pokemons")

# Load the json file
data = {}
with open("Data\\pokemon.json", encoding="utf-8") as f:
	data = json.load(f)

i = 1
# For each pokemon
for poke in data.values():
	# Potential loop breaker for testing
	if i > 25 and poke["name"] != "arceus": continue
	# if poke["name"] != "pikachu": continue

	# Find the name to use in file names
	className: str = poke["name"].title()

	# If there's an hypen, it's a form, and does not warrant a class (yet)
	if '-' in className: continue

	# Create the Species class, by opening a file
	# with open(f"Models\\Pokemons\\{className}Species.cs", 'w', encoding="utf-8") as f:
	with open(f"Models\\Pokemons\\{className}.cs", 'w', encoding="utf-8") as f:
		# Find the class the pokemon belongs to
		class_ = \
			'PokeClass.Baby' if poke["is_baby"] else \
			'PokeClass.Mythical' if poke["is_mythical"] else \
			'PokeClass.Legendary' if poke["is_legendary"] else \
			'PokeClass.Normal'

		# Find the generation the pokemon belongs to
		generation = \
			1 if poke["generation"] == "generation-i" else \
			2 if poke["generation"] == "generation-ii" else \
			3 if poke["generation"] == "generation-iii" else \
			4 if poke["generation"] == "generation-iv" else \
			5 if poke["generation"] == "generation-v" else \
			6 if poke["generation"] == "generation-vi" else \
			7 if poke["generation"] == "generation-vii" else \
			8

		# Load the template code
		outfile = f"""

using Pokedex.Models.PokemonTypes;
using Pokedex.Enums;

namespace Pokedex.Models.Pokemons
{{
	public class {className}Species : PokemonSpecies
	{{
		# region Class Variables
		private static {className}Species? _singleton;
		# endregion

		# region Properties
		public static {className}Species Singleton {{ get => _singleton is null ? _singleton = new {className}Species() : _singleton; }}
		# endregion

		# region Constructor
		public {className}Species() : base(
			{poke['id']}, "{className}",
			new List<PokemonType>(){{
				{r'''
				'''.join([f'Type{type_.title()}.Singleton,' for type_ in poke['types']])}
			}},
			new Dictionary<string, int>(){{
				{{"hp", {poke['stats']['hp']}}},
				{{"atk", {poke['stats']['attack']}}},
				{{"def", {poke['stats']['defense']}}},
				{{"spAtk", {poke['stats']['special-attack']}}},
				{{"spDef", {poke['stats']['special-defense']}}},
				{{"spd", {poke['stats']['speed']}}},
			}},

			{generation}, "{poke['genera']['en']}", {class_},
			{poke['height']}, {poke['weight']}
		) {{}}
		# endregion
	}}
}}

"""[2:-2]
		# ↑ Delete the first two and last two newlines, here for readability

		# Write the code to the file
		f.write(outfile)
	
	# Create the class, by opening a file
	# with open(f"Models\\Pokemons\\{className}.cs", 'w') as f:
		# Load the template code, and format it with the actual data
		outfile = f"""

namespace Pokedex.Models.Pokemons
{{
	public class {className} : Pokemon
	{{
		# region Constructor
		public {className}(int level) : base({className}Species.Singleton, level) {{}}
		public {className}(int level, string nickname) : base({className}Species.Singleton, level, nickname) {{}}
		public {className}(int level, string nickname, Dictionary<string, int> evs) : base({className}Species.Singleton, level, nickname, evs) {{}}
		# endregion
	}}
}}

"""[:-2]
		# ↑ Delete the first and last two newlines, here for readability

		# Append the code to the file
		f.write(outfile)
	
	i += 1