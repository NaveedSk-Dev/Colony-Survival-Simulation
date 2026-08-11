using NUnit.Framework;

public class ColonySimulationTests
{
    [Test]
    public void ThreeDaysOfConsumption_LeavesCorrectFoodReserve()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                10,
                100f,
                100f,
                1f,
                1f
            );
       
        simulation.AdvanceTime(3f);
       
        Assert.AreEqual(70f, simulation.Food);
    }

    [Test]
    public void ThreeDaysOfConsumption_LeavesCorrectWaterReserve()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                10,
                100f,
                100f,
                1f,
                2f
            );

        simulation.AdvanceTime(3f);

        Assert.AreEqual(40f, simulation.Water);
    }

    [Test]
    public void DaysRemaining_IsCalculatedFromDailyConsumption()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                10,
                100f,
                100f,
                1f,
                2f
            );

        Assert.AreEqual(
            10f,
            simulation.GetFoodDaysRemaining()
        );

        Assert.AreEqual(
            5f,
            simulation.GetWaterDaysRemaining()
        );
    }

    [Test]
    public void AdvancingThreeSeconds_AdvancesThreeGameDays()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                10,
                100f,
                100f,
                1f,
                1f
            );

        simulation.AdvanceTime(3f);

        Assert.AreEqual(3, simulation.CurrentDay);
    }

    [Test]
    public void FoodReachingZero_MakesColonyStarving()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                10,
                10f,
                100f,
                1f,
                1f
            );

        simulation.AdvanceTime(1f);

        Assert.IsTrue(simulation.IsStarving());
    }
}