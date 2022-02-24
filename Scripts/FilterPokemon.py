# Imports
import json

# Choose the pokemons to filter (whitelist)
pokemons = ["farfetchd", "meowth", "eevee"]
pokemons.extend(["persian", "victini", "incineroar", "charizard"])
pokemons.extend(["seel", "magikarp", "swanna"])
pokemons.extend(["celebi", "snivy", "kartana"])
pokemons.extend(["pikachu", "luxray", "galvantula"])
pokemons.extend(["lapras", "snom", "weavile"])
pokemons.extend(["lucario", "keldeo", "bewear"])
pokemons.extend(["venemoth", "grimer", "scolipede"])
pokemons.extend(["sandslash", "garchomp", "zygarde"])
pokemons.extend(["staraptor", "corviknight", "pidove"])
pokemons.extend(["alakazam", "mewto", "unown"])
pokemons.extend(["shedinja", "genesect", "escavalier"])
pokemons.extend(["aerodactyl", "gigalith", "diancie"])
pokemons.extend(["ghastly", "giratina", "mimikyu"])
pokemons.extend(["goodra", "kommo-o", "dragapult"])
pokemons.extend(["umbreon", "absol", "zoroark"])
pokemons.extend(["skarmory", "klinklang", "magearna"])
pokemons.extend(["jigglypuff", "mawile", "sylveon"])

# ! Theses two gods deserve this warning indicating their presence
pokemons.extend(["bidoof", "wooloo"])

# Loads in the full data
with open("Data/pokemon.json", 'r', encoding="utf-8") as f:
	database = json.load(f)

# Uses dict comprehension to whitelist the selected pokemons
newData = {poke: database[poke] for poke in database if poke in pokemons}

# Write them into a new JSON file
with open("Data/pokemons2.json", 'w', encoding="utf-8") as f:
	json.dump(newData, f, indent=2, sort_keys=True, ensure_ascii=False)