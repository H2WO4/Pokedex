import requests
import json

contents = {}
for i in range(1, 827):
	content = json.loads(requests.get(f"https://pokeapi.co/api/v2/move/{i}").content)
	contents[content["name"]] = content

with open("moves.json", 'w') as f:
	json.dump(contents, f, indent=2)
