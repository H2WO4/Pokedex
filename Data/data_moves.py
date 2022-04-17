import json

contents = {}
with open("moves_raw.json", 'r') as f:
	contents = json.load(f)

for move in contents.values():
	try:
		move["description"] = move["effect_entries"][0]["short_effect"]
	except:
		move["description"] = ""

	for var in ["contest_combos", "contest_effect", "contest_type", "effect_changes", "super_contest_effect",
	            "flavor_text_entries", "effect_entries", "learned_by_pokemon", "past_values", "machines"]:
		del move[var]

	for var in ["target", "type", "damage_class", "generation"]:
		move[var] = move[var]["name"]

	for key, val in move["meta"].items():
		if isinstance(val, dict):
			move["meta"][key] = move["meta"][key]["name"]

	move["names"] = {name["language"]["name"]: name['name'] for name in move["names"]}

	for i, _ in enumerate(move["stat_changes"]):
		move["stat_changes"][i]["stat"] = move["stat_changes"][i]["stat"]["name"]

	for var, val in move["meta"].items():
		move[var] = val
	del move["meta"]

	move["ailment"] = {"type": move["ailment"], "chance": move["ailment_chance"]}
	del move["ailment_chance"]

with open("moves.json", 'w', encoding="utf8") as f:
	json.dump(contents, f, indent=2, ensure_ascii=False)
