# Imports
import json
import os
import re
import shutil

# Remove previous files
shutil.rmtree("Models/PokeMoves")
os.mkdir("Models/PokeMoves")
for sub in ["Basic", "Effect", "OHKO",
            "StatusEffect", "Unique", "StatChange",
            "Drain", "BonusEffect", "Heal",
            "Special", "MultiHit", "Recoil",
            "Healing", "Recharge", "Switch"]:
    os.mkdir(f"Models/PokeMoves/{sub}")

# Load the json file
data: dict
with open("Data/moves.json", encoding="utf-8") as f:
    data = json.load(f)

# For each move in the list
subfolder = ""
outfile = ""
for moveName in data.keys():
    move = data[moveName]

    if move["id"] >= 719:
        break

    # Find the name to use in file names
    moveName = moveName.replace('-', ' ').title()
    moveNameNoSpace = moveName.replace(' ', '')

    normalDesc = ["Inflicts regular damage with no additional effect.",
                  "Has an increased chance for a critical hit.",
                  "Has a $effect_chance% chance to make the target flinch.",
                  "Inflicts regular damage and can hit Pokémon in the air.",
                  "Never misses.",
                  "Inflicts regular damage and can hit Dive users.",
                  "Inflicts regular damage and can hit Dig users."]

    dblHitDesc = ["Hits twice in one turn."]

    multiHitDesc = ["Hits 2-5 times in one turn."]

    rechargeDesc = ["User foregoes its next turn to recharge."]

    switchDesc = ["User must switch out after attacking."]

    # Load the template code
    match move["category"]:
        case "damage" if move["flinch_chance"] == 0 and move["description"] in normalDesc:
            # Basic move
            subfolder = "/Basic"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if move["description"] in normalDesc:
            # Basic move with flinch
            subfolder = "/Effect"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{{
    public int EffectChance
        => {move["flinch_chance"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if move["description"] in dblHitDesc:
            # Basic double hit move
            subfolder = "/MultiHit"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_DoubleHit
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if move["description"] in multiHitDesc:
            # Basic multi-hit move
            subfolder = "/MultiHit"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_MultiHit
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if move["description"] in rechargeDesc:
            # Basic move with recharge
            subfolder = "/Recharge"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if move["description"] in switchDesc:
            # Basic move with switch-out
            subfolder = "/Switch"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_SwitchAfter
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage" if "recoil" in move["description"]:
            # Basic move with other effects
            subfolder = "/Recoil"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_Recoil
{{
    public int RecoilPower
        => {-move["drain"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage":
            # Basic move with other effects
            subfolder = "/Special"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "ohko":
            # OHKO
            subfolder = "/OHKO"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_OHKO
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage+ailment":
            # Move with added effect
            subfolder = "/Effect"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatusEffectBonus<{move["ailment"]["type"].title().replace('-', '')}Effect>
{{
    public int EffectChance
        => {move["ailment"]["chance"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage+heal":
            # Move with added effect
            subfolder = "/Drain"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_Drain
{{
    public int DrainPower
        => {move["drain"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage+lower":
            # Move with added effect
            stats = """
            """.join([f"yield return Stat.{move['stat_changes'][i]['stat'].title().replace('-', '')};" for i in
                      range(len(move["stat_changes"]))])
            values = """
            """.join([f"yield return {move['stat_changes'][i]['change']};" for i in range(len(move["stat_changes"]))])

            subfolder = "/BonusEffect"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatChangeBonus
{{
    public IEnumerable<Stat> StatsToChange
    {{
        get
        {{
            {stats}
        }}
    }}

    public IEnumerable<int> ChangeValues
    {{
        get
        {{
            {values}
        }}
    }}

    public int EffectChance
        => {move["stat_chance"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "damage+raise":
            # Move with added effect
            stats = """
            """.join([f"yield return Stat.{move['stat_changes'][i]['stat'].title().replace('-', '')};" for i in
                      range(len(move["stat_changes"]))])
            values = """
            """.join([f"yield return {move['stat_changes'][i]['change']};" for i in range(len(move["stat_changes"]))])

            subfolder = "/BonusEffect"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatChangeBonusUser
{{
    public IEnumerable<Stat> StatsToChange
    {{
        get
        {{
            {stats}
        }}
    }}

    public IEnumerable<int> ChangeValues
    {{
        get
        {{
            {values}
        }}
    }}

    public int EffectChance
        => {move["stat_chance"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "ailment":
            # Status move
            subfolder = "/StatusEffect"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatusEffect<{move["ailment"]["type"].title().replace('-', '')}Effect>
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "heal":
            # Status move
            subfolder = "/Healing"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_Heal
{{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => {move["healing"]};

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "net-good-stats" if move["target"] == "user":
            # Only stat change, for user
            stats = """
            """.join([f"yield return Stat.{move['stat_changes'][i]['stat'].title().replace('-', '')};" for i in
                      range(len(move["stat_changes"]))])
            values = """
            """.join([f"yield return {move['stat_changes'][i]['change']};" for i in range(len(move["stat_changes"]))])

            subfolder = "/StatChange"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatChange, IM_TargetSelf
{{
    public IEnumerable<Stat> StatsToChange
    {{
        get
        {{
            {stats}
        }}
    }}

    public IEnumerable<int> ChangeValues
    {{
        get
        {{
            {values}
        }}
    }}

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "net-good-stats":
            # Only stat change, for opponents
            stats = """
            """.join([f"yield return Stat.{move['stat_changes'][i]['stat'].title().replace('-', '')};" for i in
                      range(len(move["stat_changes"]))])
            values = """
            """.join([f"yield return {move['stat_changes'][i]['change']};" for i in range(len(move["stat_changes"]))])

            subfolder = "/StatChange"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, IM_StatChange
{{
    public IEnumerable<Stat> StatsToChange
    {{
        get
        {{
            {stats}
        }}
    }}

    public IEnumerable<int> ChangeValues
    {{
        get
        {{
            {values}
        }}
    }}

    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case "force-switch":
            # Forces the opponent to switch out
            subfolder = "/Unique"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove, I_Skill
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}

    void I_Skill.DoAction(I_Battler target)
    {{
        var possibleSwitch = new int[target.Owner.Team.Length];
        int newIndex =
            possibleSwitch.Where(i => target.Owner.Team[i]
                                   != target.Owner.Active)
                          .Where(i => target.Owner.Team[i].CurrHP
                                    > 0)
                          .MinBy(_ => Program.Rnd.Next());

        target.Owner.ChangeActive(newIndex, true);
    }}
}}

"""[2:-2]

        case "field-effect" | "whole-field-effect" | "swagger":
            # Fuck it, too bothersome to implement
            continue

        case "unique":
            # Case-by-case moves
            subfolder = "/Unique"
            outfile = f"""

using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class Move{moveNameNoSpace} : PokeMove
{{
    public Move{moveNameNoSpace}()
        : base("{moveName}",
               MoveClass.{move["damage_class"].title()},
               {move["power"] or "null"}, {move["accuracy"] or "null"}, // Pow & Acc
               {move["pp"]}, {move["priority"]}, // PP & Priority
               Type{move["type"].title()}.Singleton) {{ }}
}}

"""[2:-2]

        case _:
            subfolder = ""
            outfile = ""

    # Create the PokemonMove class, by opening a file
    with open(f"Models/PokeMoves{subfolder}/Move{moveNameNoSpace}.cs", 'w', encoding="utf-8") as f:
        # Write the code to the file
        f.write(outfile)
