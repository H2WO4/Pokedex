import json
import requests

with open("Data/pokemon_raw.json", 'r') as f:
    contents = json.load(f)

for poke in contents.values():
    species = json.loads(requests.get(poke["species"]["url"]).content)
    form = json.loads(requests.get(poke["forms"][0]["url"]).content)

    poke["id"] = species["id"]

    for var in ["forms", "game_indices", "held_items",
                "is_default", "location_area_encounters",
                "sprites", "order", "past_types"]:
        del poke[var]

    poke["abilities"] = [ability["ability"]["name"] for ability in poke["abilities"]]
    poke["moves"] = [move["move"]["name"] for move in poke["moves"]]
    poke["types"] = [types["type"]["name"] for types in poke["types"]]
    poke["stats"] = {stat["stat"]["name"]: stat["base_stat"] for stat in poke["stats"]}

    poke["battle_form"] = form["is_battle_only"]
    del poke["species"]
    for var in ["is_baby", "is_legendary", "is_mythical", "hatch_counter", "gender_rate", "capture_rate"]:
        poke[var] = species[var]

    for var in ["color", "shape", "habitat", "generation", "growth_rate"]:
        if species[var] is not None:
            poke[var] = species[var]["name"]
        else:
            poke[var] = None

    poke["egg_groups"] = [egg["name"] for egg in species["egg_groups"]]
    poke["names"] = {name["language"]["name"]: name["name"] for name in species["names"]}
    poke["genera"] = {genus["language"]["name"]: genus["genus"] for genus in species["genera"]}

with open("Data/pokemon.json", 'w', encoding="utf8") as f:
    json.dump(contents, f, indent=2, ensure_ascii=False)
