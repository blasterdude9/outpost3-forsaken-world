# Outpost 3: Forsaken World

A fan-made spiritual successor to Outpost 2, built in VB.NET using the Irrlicht.NET engine.

## Factions

| Faction | Power Plant | Specialty |
|---------|-------------|-----------|
| **Eden** | Tokamak Fusion Reactor | Balanced tech, Spider walker, Thor's Hammer |
| **Plymouth** | MHD Generator | Heavy armor, EMP, Nursery population boom |
| **Gemini** | Solar Collector | Cheapest buildings, can produce all vehicle types |
| **Microbe** | Bioreactor | Blight weapons, Arachnid walkers, self-repairing units |

## Architecture

```
Classes/
  Engine/         - Irrlicht wrapper (IrrlichtObj)
  Game/
    Player/       - AbstractPlayer, AI (Dumb/Mean), collections
    Unit/
      Building/   - All faction buildings (Eden/Plymouth/Gemini/Microbe)
      Vehicle/    - Combat, Construction, Transport vehicles
    Weapon/       - All faction weapons
    Util/         - DamageVector
  GameLoop.vb     - Main simulation tick (2s/mark)
  GameMap.vb      - Tile grid, ore deposits, tube network, blight
  ResourceManager.vb - Power/ore/population/morale ticks
  BuildQueue.vb   - Queued construction system
  BuildingFactory.vb - String → BuildOrder factory
  VehicleFactory.vb  - String → Vehicle factory
```

## Building

Requires Visual Studio 2008+ and the IrrNetCP SDK (Irrlicht.NET wrapper).

1. Clone the repo
2. Copy the IrrNetCP SDK to `../../Development/IrrNetCP_SDK_0.8/`  
   (or update the reference path in the `.vbproj`)
3. Open `Outpost 3 Forsaken World.vbproj` in Visual Studio
4. Build → Debug

## Status

- [x] All 4 factions fully implemented (buildings, vehicles, weapons)
- [x] Resource simulation (power, ore, population, morale)
- [x] Build queue system
- [x] AI players (Dumb = passive economy, Mean = rush aggressor)
- [x] Game loop with win condition detection
- [x] Map system with ore deposits, lava terrain, blight spread
- [ ] Rendering / 3D models (mesh files not yet created)
- [ ] Input handling / player controls
- [ ] Networking
