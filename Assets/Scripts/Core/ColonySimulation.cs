using System;

public class ColonySimulation
{
    private readonly int villagers;
    private readonly float foodPerVillagerPerDay;
    private readonly float waterPerVillagerPerDay;

    private float elapsedGameTime;

    public float Food { get; private set; }
    public float Water { get; private set; }

    public int CurrentDay { get; private set; }

    public ColonySimulation(
        int villagers,
        float startingFood,
        float startingWater,
        float foodPerVillagerPerDay,
        float waterPerVillagerPerDay)
    {
        this.villagers = villagers;
        this.foodPerVillagerPerDay = foodPerVillagerPerDay;
        this.waterPerVillagerPerDay = waterPerVillagerPerDay;

        Food = startingFood;
        Water = startingWater;

        CurrentDay = 0;
        elapsedGameTime = 0f;
    }

    public void AdvanceTime(float deltaTime)
    {
        elapsedGameTime += deltaTime;

        while (elapsedGameTime >= 1f)
        {
            elapsedGameTime -= 1f;

            AdvanceOneDay();
        }
    }

    private void AdvanceOneDay()
    {
        float dailyFoodConsumption =
            villagers * foodPerVillagerPerDay;

        float dailyWaterConsumption =
            villagers * waterPerVillagerPerDay;

        Food = Math.Max(
            0f,
            Food - dailyFoodConsumption
        );

        Water = Math.Max(
            0f,
            Water - dailyWaterConsumption
        );

        CurrentDay++;
    }

    public float GetFoodDaysRemaining()
    {
        float dailyFoodConsumption =
            villagers * foodPerVillagerPerDay;

        if (dailyFoodConsumption <= 0f)
        {
            return float.PositiveInfinity;
        }

        return Food / dailyFoodConsumption;
    }

    public float GetWaterDaysRemaining()
    {
        float dailyWaterConsumption =
            villagers * waterPerVillagerPerDay;

        if (dailyWaterConsumption <= 0f)
        {
            return float.PositiveInfinity;
        }

        return Water / dailyWaterConsumption;
    }

    public bool IsStarving()
    {
        return Food <= 0f || Water <= 0f;
    }
}