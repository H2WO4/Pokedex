# Imports
import json
import os
import shutil

# Delete the old folder
shutil.rmtree("Models/Pokemons")
os.mkdir("Models/Pokemons")

# Load the json file
with open("Data/pokemon.json", encoding="utf-8") as f:
    data = json.load(f)

with open("Data/new_pokemon.json", encoding="utf-8-sig") as f:
    temp_data = json.load(f)
    for poke in temp_data:
        data[poke] = temp_data[poke]

i = 1
# For each pokemon
for poke in data.values():
    # if poke["id"] > 36 and poke["name"] != "arceus":
    #     continue

    # Find the name to use in file names
    className: str = poke["name"].title()
    name: str = className.split('-')[0]
    className = className.replace('-', '')

    # Create the Species class, by opening a file
    # with open(f"Models/Pokemons/{className}Species.cs", 'w', encoding="utf-8") as f:
    with open(f"Models/Pokemons/{className}.cs", 'w', encoding="utf-8") as f:
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
    public class {className} : PokeSpecies
    {{
        #region Class Variables
        private static {className}? _singleton;
        #endregion

        #region Properties
        public static {className} Singleton
            => _singleton ??= new {className}();
        #endregion

        #region Constructor
        public {className}()
            : base({poke['id']}, "{name}",
                   new List<PokeType> {{ {', '.join([f'Type{type_.title()}.Singleton' for type_ in poke['types']])} }},
                   new Dictionary<Stat, int>
                   {{
                       {{ Stat.HP, {poke['stats']['hp']} }}, {{ Stat.Atk, {poke['stats']['attack']} }}, {{ Stat.Def, {poke['stats']['defense']} }},
                       {{ Stat.SpAtk, {poke['stats']['special-attack']} }}, {{ Stat.SpDef, {poke['stats']['special-defense']} }}, {{ Stat.Spd, {poke['stats']['speed']} }},
                   }},
                   {generation}, "{poke['genera']['en']}", {class_},
                   {poke['height']}, {poke['weight']}{r''', true''' if poke["battle_form"] else ""}) {{ }}
        #endregion
    }}
}}

"""[2:-2]
        # ↑ Delete the first two and last two newlines, here for readability

        # Write the code to the file
        f.write(outfile)

    i += 1
