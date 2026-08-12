# Colony Survival Prototype

A small Unity prototype that simulates a colony's food and water reserves depleting over accelerated game time.

The prototype loads population and consumption values from JSON configuration files, runs the simulation through pure C# logic, and presents the current reserves, days remaining, game day, and starvation state through a Unity UI.

## Overview

This project is a small prototype for a mobile-first colony survival game.

The prototype simulates:

- Villager population
- Food reserves
- Water reserves
- Daily resource consumption
- Accelerated game time
- Food and water days remaining
- Colony starvation

For the trial, 1 real second represents 1 game day.

## Unity Version

- Unity 6000.3.13f1
- Development platform: Windows
- Target platform: Android / iOS

## How to Run

1. Clone or download the repository.
2. Open the project using the Unity version specified above.
3. Open:
   `Assets/Scenes/ColonySurvival.unity`
4. Press Play in the Unity Editor.
5. The simulation starts automatically.
6. Food and water decrease over time.
7. 1 real second represents 1 game day.
8. When either reserve reaches zero, the colony enters the `COLONY STARVING` state.

## Configuration

The simulation configuration is loaded from two JSON files:

- `Assets/Resources/population.json`
- `Assets/Resources/consumption.json`

`population.json` contains:

- Villager count
- Starting food
- Starting water

`consumption.json` contains:

- Food consumption per villager per game day
- Water consumption per villager per game day

No population, starting-reserve, or consumption values are hardcoded in the simulation code.

## Architecture

The simulation logic is separated from Unity-specific presentation code.

### Pure C# simulation

`ColonySimulation.cs` is a plain C# class. It does not inherit from `MonoBehaviour` and does not reference `UnityEngine`.

It is responsible for:

- Advancing game time
- Calculating daily food consumption
- Calculating daily water consumption
- Updating reserves
- Calculating days remaining
- Tracking the current game day
- Detecting starvation

### Unity layer

Unity-specific scripts are responsible for integration and presentation:

- `GameBootstrap.cs` loads the JSON configuration and creates the simulation.
- `ColonyUI.cs` displays the current simulation state.
- `JsonLoader.cs` loads the JSON TextAssets.

The UI does not perform simulation calculations.

### Data flow

population.json ───────┐
                       │
                       ▼
                 GameBootstrap
                       │
consumption.json ──────┤
                       ▼
               ColonySimulation
                       │
             ┌─────────┼─────────┐
             ▼         ▼         ▼
           Food      Water     Game Day
             │         │         │
             └─────────┼─────────┘
                       ▼
                   ColonyUI
                       │
                       ▼
                  Unity UI

## Tests

The simulation includes EditMode unit tests using Unity Test Framework.

The tests verify:

- Food consumption
- Water consumption
- Food days remaining
- Water days remaining
- Game-day advancement
- Starvation detection
- Simulation stopping after starvation

### Running the tests

1. Open the project in Unity.
2. Open `Window > General > Test Runner`.
3. Select `EditMode`.
4. Click `Run All`.
5. All tests should pass.

## AI Tools Used

I used ChatGPT as an AI development assistant during the trial for architecture discussion, implementation guidance, debugging, unit-test ideas, and README preparation.

I reviewed and integrated the generated suggestions into the Unity project myself, including the project setup, configuration files, Unity scene setup, Inspector references, testing, and final verification.

## Decisions & Trade-offs

The prototype intentionally keeps the presentation minimal and focuses on the required simulation and architecture.

I used `Resources` to load the provided JSON configuration files because the trial only requires startup configuration loading and does not require a larger content-addressing system.

The simulation stops advancing once food or water reaches zero so the starvation state becomes a stable final state for the prototype and demo.

The UI is intentionally simple and uses Unity UI/TextMeshPro rather than spending time on art, animation, sound, or additional gameplay features that were outside the scope of the trial.

## Mobile Considerations

The UI uses a responsive Canvas configuration with `Scale With Screen Size` so the prototype can be presented in a Landscape-oriented mobile layout.

No mobile-specific gameplay controls were added because they were outside the scope of this trial.

## Demo

Demo video:

TODO — add demo video link before submission.

## Git History

The project was developed incrementally with meaningful commits:

- `Initial Unity project`
- `Added JSON configuration loading`
- `Implemented colony simulation and unit tests`
- `Connected simulation to Unity runtime`
- `Stop simulation when colony is starving`
- `Added colony status UI`
- `Cleaned up prototype and verified runtime`