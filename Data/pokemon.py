import requests
import re
import json

links: list[str] = []
content = json.loads(requests.get("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0").content)
for res in content["results"]:
	links.append(res["url"])

contents = {}
for link in links:
	i = re.findall(r"^.*pokemon/(\d+)/$", link)[0]

	content = json.loads(requests.get(link).content)
	contents[i] = content

with open("Data/pokemon_raw.json", 'w') as f:
	json.dump(contents, f, indent=2)
