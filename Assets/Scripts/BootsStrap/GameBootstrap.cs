using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField]
    private ColonyUI colonyUI;

    private ColonySimulation simulation;

    private bool starvationLogged;

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

        colonyUI.Refresh(simulation);

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

        colonyUI.Refresh(simulation);

            if (simulation.IsStarving() && !starvationLogged)
            {
                starvationLogged = true;

                Debug.LogWarning("COLONY STARVING");
            }
        
    }
}