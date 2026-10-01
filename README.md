# Dungeon Depths — Unofficial Community Fixes

Unofficial community maintenance of Dungeon Depths v13, keeping the game playable with small bug fixes and quality-of-life improvements.

**18+ only.** Dungeon Depths contains adult transformation and hypnosis themes. As requested in the original project, please do not play the game or browse its source if you are under 18.

## About this project

Dungeon Depths was created by **VowelHeavyUsername (VHU)**. This project builds on their work and the contributions included in the original game.

- **Original project:** [Dungeon Depths on Bitbucket](https://bitbucket.org/VowelHeavyUsername/dungeon_depths/)
- **Community maintainer:** MrAlixter
- **Starting point:** v13 source at commit `fa7406a38e516159149057d6e2e6532d76590f50`

I started fixing issues I encountered while playing and wanted to share those fixes with other players. The aim is to maintain a version we can enjoy together, address small bugs, and make everyday use more convenient while preserving the original game.

This is an **unofficial community project**, not an official release or an announcement on behalf of the original author. There is no fixed update schedule; changes are made as time and testing allow.

## Current fixes and improvements

- Build compatibility with .NET Framework 4.8.
- Save-preview initialization and inventory-selection fixes.
- Chest loot initialization on the legacy floor.
- More robust processing of the update queue.
- A fix for Scholastic Scrunchie calculations when the class WILL multiplier is zero.
- A fix for Heavy Blow calculations against enemies with zero speed.
- **F5 quick save** with visible success/failure notifications.
- Local diagnostic logging for selected item and special-ability failures.

F5 uses the last successfully loaded or saved numbered slot. If no slot has been selected, it opens the usual slot-selection flow. Existing saving restrictions still apply, including during combat.

## Playing and testing

A downloadable Windows test build is being prepared. When a build is published, it will be listed under this repository's **Releases** and marked **Pre-release** while testing continues.

For a packaged build:

1. Extract the entire game archive into a separate folder.
2. Keep the executable, configuration file, and image assets together.
3. Run `Dungeon_Depths.exe` on Windows with .NET Framework 4.8 installed.
4. Back up existing saves before trying a community build; test with copies.

GitHub's automatically generated **Source code** archives are not ready-to-play builds.

## Building from source

For a checkout containing the patched game source:

1. Install Visual Studio with VB.NET/.NET desktop development support and the .NET Framework 4.8 targeting pack.
2. Open `dungeon_depths_vb/The Dungeon.sln`.
3. Select **Debug / Any CPU** and rebuild the solution.
4. Run `dungeon_depths_vb/The Dungeon/bin/Debug/Dungeon_Depths.exe` from its output folder, keeping the copied `img` folder alongside it.

The initial fixes were built and smoke-tested on Windows using Visual Studio 2026. Release/installer configurations have not been validated. The game's internal version remains `13.0`; use the community release tag to identify a particular test build.

## Testing and known issues

Windows checks included loading a copied save, inspecting and using items, ordinary combat, quick saving, and restarting/reloading the game.

Focused tests passed for Scholastic Scrunchie (9 calculation cases), Heavy Blow (7 source-level cases), and the diagnostic logger (7 checks). These cover specific behavior, not every gameplay combination, and were run during development rather than as a complete suite against every later revision.

Known limitations include:

- Not every item, spell, transformation, or historical save has been tested.
- Diagnostic logging covers selected code paths and may not capture every failure.
- The original rare crashes are not all reproducible in a recorded gameplay test.

## Reporting bugs

Please open an **Issue** with:

- The community release tag and your Windows version.
- What you were doing and what you expected to happen.
- Steps to reproduce the problem, if known.
- Relevant item/spell names, character class/form, and floor number.
- A screenshot or error message.

If available, attach the relevant report from `%LOCALAPPDATA%\DungeonDepths\Logs\errors.log`. Check logs for personal paths or other information you do not want to share. If a save is needed, share a copy rather than your only original.

It is still useful to report a crash even if you cannot reproduce it. Please distinguish what you remember from what you are unsure about.

## Contributing and credits

Small, focused fixes and clear bug reports are welcome. For a pull request, explain the problem, what changed, how you tested it, and what name you would like to be credited under. Please keep unrelated changes separate.

AI assistance was used for code changes, test scripts, and documentation. Windows builds and gameplay checks were performed by the community maintainer. These changes still benefit from human review and wider testing.

Credit for the original game belongs to VowelHeavyUsername and its original contributors. Existing credits and notices should be preserved. This README does not add a new license or grant permission to redistribute the original code or assets; upstream terms and any separate asset permissions still apply.
