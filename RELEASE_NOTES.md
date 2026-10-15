# Dungeon Depths v13.0 — Unofficial Community Fixes #2

An updated unofficial community build of Dungeon Depths v13.0, focused on save loading, status effects, combat abilities, and Junk Chime sales.

## Changes

- **Dodge:** selecting the ability now uses Dodge instead of opening Shapeshift.
- **Thief's Longcoat:** corrected the item's name from "Theif's Longcoat" and kept support for the old saved name so the coat stays equipped when loading existing saves. Legacy inventories also recognize the old name.
- **Mesmerized:** the remaining duration now counts down, allowing the status to expire during combat and exploration.
- **Save loading:** fixed a case where a save on floor 4 with Ooze Empress and initialized Junk Chime data could be reported as corrupt. The loader now advances past the temporary inventory before reading the chime data.
- **Junk Chime save data:** loading a save without chime data now clears the previous session's chime state, including when loading older saves.
- **Junk Chime sales:** fixed the calculation for spare copies of equipped items. It now retains the worn copy and pays for the others instead of potentially subtracting gold. The existing sale rate is unchanged.
- **Helix Slash:** fixed healing being rounded to zero or a whole health bar. Healing now preserves fractional values and stops at maximum HP.
- **Dodge and reflection:** a successfully avoided hit no longer proceeds into Inferno Aura or Hallowed Talisman damage-reflection handling. This also prevents a successful dodge from being lost on lethal hits or when no reflection target is available.
- **Will Up:** the bonus is applied when the ability is used, instead of being added again automatically on every turn. Deliberate recasts, stamina costs, and the existing duration/expiration handling are unchanged.

**Will Up note:** it will be less powerful than the bugged version that increased WILL automatically each turn.

## Playing this build

Download `Dungeon-Depths-Community-Test-2.zip` from the release assets, extract the entire archive into a new folder, and run `Dungeon_Depths.exe`. Windows and .NET Framework 4.8 are required.

Back up existing saves and use copies when trying the update. These fixes do not change the save format. Automatically generated GitHub source archives are not ready-to-play game packages.

## Reporting bugs

Please report problems through GitHub Issues with the release tag `v13.0-community.2`, what happened, and reproduction steps if available. For crashes, a relevant excerpt from `%LOCALAPPDATA%\DungeonDepths\Logs\errors.log` may help; logging does not cover every possible failure.

Dungeon Depths was created by **VowelHeavyUsername**. This is an unofficial community update maintained by **MrAlixter**, not an official release from the original developer. AI assistance was used for code and documentation; see the README for credits.
