# Reset Traffic

**Alpha** (`1.1.0-alpha`). A Cities: Skylines II mod with one Options button that removes **moving** vehicles so traffic can respawn from demand.

Official `IMod` (no Harmony, no BepInEx). MIT licensed. Source: [github.com/mafra-code/cs2-reset-traffic](https://github.com/mafra-code/cs2-reset-traffic).

## Usage

1. Load a city (the button is disabled on the main menu).
2. ESC → **Options** → **Reset Traffic** → **Reset vehicles**.
3. Confirm, **close Options**, then set game speed to **1**. Vehicles despawn over several seconds while time is running. The reset is a **one-shot snapshot** of entities that exist at that moment; anything that spawns afterwards is left alone. Extra button or hotkey presses while a reset is running are ignored.

The Options page shows **Idle** or **Running**, plus **Remaining** / **Removed** / **Snapshot** counts. **Debugging** writes verbose lines to `Mods_ResetTraffic.log` and will hitch; leave it off unless you need those logs.

You can also use a **hotkey** (default **F9**). **Entities per frame** (1–64, default 20) and **Extra frames between batches** (0–30, default 0) control how fast things disappear.

**Moving vehicles and pedestrians:** cars, bicycles, trains, public transport, trucks/service, aircraft/watercraft (on by default), pedestrians (off).

**Parked:** parked cars, bicycles, trains, and other parked vehicles (all off by default). Parked cars include garage/depot fleets (fire, buses, …), not only street parking.

Progress is written to:

`%USERPROFILE%\AppData\LocalLow\Colossal Order\Cities Skylines II\Logs\Mods_ResetTraffic.log`

## Install

Subscribe on [Paradox Mods](https://mods.paradoxplaza.com/mods/159366/Windows), or build from source (below). A Release build copies the mod to:

`%USERPROFILE%\AppData\LocalLow\Colossal Order\Cities Skylines II\Mods\ResetTraffic`

Skyve and the game load that local Mods folder automatically. **Close the game before building** — otherwise the DLL is locked.

## Publish (Paradox Mods)

Requires the in-game **Modding toolchain**, a Paradox account already logged in through Cities: Skylines II or Skyve, and `ResetTraffic/Properties/PublishConfiguration.xml` (`ModId` **159366**). **Close the game first.**

First upload is done. Later code updates: bump `Version` / `ModVersion` / changelog, then:

```bash
dotnet publish ResetTraffic/ResetTraffic.csproj -c Release -p:PublishProfile=NewVersion
```

Listing text / thumbnail only (no rebuild of the package): `-p:PublishProfile=Update`.

## Build

Requires:

- Cities: Skylines II with the in-game **Modding toolchain** applied once (sets the `CSII_*` user environment variables)
- .NET SDK that can target .NET Framework 4.8

```bash
dotnet build ResetTraffic/ResetTraffic.csproj -c Release
```

Tested against game version **1.6.2f1**.

## Project layout

```
ResetTraffic.sln
ResetTraffic/
  Mod.cs                 # IMod entry, Options registration
  Setting.cs             # Reset vehicles button
  LocaleEN.cs / LocaleDE.cs
  Systems/ResetTrafficSystem.cs
```

The system runs at `ToolUpdate`. On start it snapshots matching entities, then tags those with `Deleted` via `ToolOutputBarrier` while simulation speed is greater than 0. It does not keep deleting respawns. Batch size and extra frame delay are Options sliders.

## Known bugs

- **Hotkey rebind does not stick.** Options can open the key-binding dialog, but the new key is not saved or shown afterward. Default remains **F9**.

## License

[MIT](LICENSE) © 2026 MafraCode

Cities: Skylines II is a trademark of Paradox Interactive / Colossal Order. This project is not affiliated with or endorsed by them.
