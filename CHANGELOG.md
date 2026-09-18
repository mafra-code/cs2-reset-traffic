# Changelog

All notable changes to this project are documented in this file.

The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
Versions use `major.minor.patch-alpha|beta`. Newest first.

## [1.0.0-beta] - 2026-09-18

Player-facing first beta. Folds unpublished 1.1.x-alpha git history (`0911078` 1.1.1-alpha, `57b725a` 1.1.0-alpha) into this listing version. Paradox Mods listing is still **1.0.0-alpha** until NewVersion.

### Added

- Options strings for every Cities: Skylines II language (`en-US`, `de-DE`, `es-ES`, `fr-FR`, `it-IT`, `ja-JP`, `ko-KR`, `pl-PL`, `pt-BR`, `ru-RU`, `zh-HANS`, `zh-HANT`). English and German remain human translations; all others are AI-generated.

### Changed

- Parked cars and bicycles are **on by default** (includes garage/depot/service fleets, not only street parking). Parked trains and other parked stay off.
- **Reset to defaults** sits in its own Options group **before Moving**, so a header separates it from the type filters. Still does not change the hotkey.
- Options **Status** line (idle/running, remaining / removed / snapshot) replaces the dummy Idle checkbox, which did not show in Options. Re-open the page if the line is stale.
- Paradox listing screenshots: keep before-jam and after-clear; replace the old Options shot with two new Options pages (top and bottom, 2026-09-18). Options title is **Reset Traffic (Beta)**.

## [1.1.0-alpha] - 2026-09-18

Git `57b725a`. Tag `v1.1.0-alpha`. Git-only history; never published to Paradox Mods. Folded into **1.0.0-beta**.

### Added

- **Reset to defaults** button: restores type filters, pace sliders, and debugging. Confirm dialog. Does not reset the hotkey or start a traffic reset.

### Changed

- **Entities per frame** default is **20** (was 16). Existing `Mods_ResetTraffic.coc` keeps the old value until Reset to defaults.

## [1.0.0-alpha] - 2026-09-16

First public release. Paradox Mods **#159366**. Git `41394cb` (history was pruned; this is the first published snapshot). Tested on game **1.6.2f1**.

### Added

- Official `IMod` (no Harmony): one Options button (or **F9**) that snapshots matching entities and despawns that set via `ToolOutputBarrier` at `ToolUpdate` while simulation speed is greater than 0. Later spawns are left alone. Extra presses while a reset is running are ignored.
- Type filters: moving cars, bicycles, trains, public transport, trucks/service, aircraft/watercraft (on); pedestrians (off). Parked cars, bicycles, trains, other (all off). Parked cars include garage/depot fleets.
- **Entities per frame** (1–64, default 16) and **Extra frames between batches** (0–30, default 0).
- English and German Options strings. Debug logging to `Mods_ResetTraffic.log`.
- Paradox Mods listing, thumbnail, GitHub source link, and before/after Options screenshots (same-day listing updates; version not bumped).

### Known

- Hotkey rebind dialog opens, but the new key is not saved. Default remains **F9**.

## [0.1.0-alpha]

Internal pre-publish builds (2026-09-15). Not in git; no public dates. Crash-loop until the snapshot + barrier path that shipped as 1.0.0-alpha.

### Notes

- Immediate `Deleted` tags crashed the game (native UNKNOWN after Options close). `Unspawned` instead of `Deleted` bounced remaining counts without finishing.
- Snapshot at start, delete only that set, skip spawn-pending (`Unspawned`). Batch despawn per Unity render frame through `ToolOutputBarrier`.
- Default hotkey **F9** (a none-binding never registered). Options progress (remaining / removed / snapshot); ignore extra reset requests while one is running.
