using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private ColonySimulation simulation;

    private int lastLoggedDay = -1;

    private void Start()
    {
        PopulationConfig population =
            JsonLoader.Load<PopulationConfig>("population");

        ConsumptionConfig consumption =
            JsonLoader.Load<ConsumptionConfig>("consumption");

        if (population == null)
        {
            Debug.LogError("Population configuration could not be loaded.");
            return;
        }

        if (consumption == null)
        {
            Debug.LogError("Consumption configuration could not be loaded.");
            return;
        }

        simulation = new ColonySimulation(
            population.villagers,
            population.startingFood,
            population.startingWater,
            consumption.foodPerVillager,
            consumption.waterPerVillager
        );

        Debug.Log(
            $"Colony initialized. " +
            $"Villagers: {population.villagers}, " +
            $"Food: {simulation.Food}, " +
            $"Water: {simulation.Water}"
        );
    }

    private void Update()
    {
        if (simulation == null)
        {
            return;
        }

        simulation.AdvanceTime(Time.deltaTime);

        if (simulation.CurrentDay != lastLoggedDay)
        {
            lastLoggedDay = simulation.CurrentDay;

            if (simulation.CurrentDay > 0)
            {
                Debug.Log(
                    $"Game Day {simulation.CurrentDay} | " +
                    $"Food: {simulation.Food:F1} | " +
                    $"Water: {simulation.Water:F1}"
                );

                if (simulation.IsStarving())
                {
                    Debug.LogWarning("COLONY STARVING");
                }
            }
        }
    }
}