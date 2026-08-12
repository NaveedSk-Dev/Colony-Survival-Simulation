using TMPro;
using UnityEngine;

public class ColonyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text foodDaysText;
    [SerializeField] private TMP_Text waterDaysText;
    [SerializeField] private TMP_Text gameDayText;
    [SerializeField] private TMP_Text statusText;

    public void Refresh(ColonySimulation simulation)
    {
        foodText.text =
            $"Food Stored: {simulation.Food:F1}";

        waterText.text =
            $"Water Stored: {simulation.Water:F1}";

        foodDaysText.text =
            $"Food Days Remaining: {FormatDays(simulation.GetFoodDaysRemaining())}";

        waterDaysText.text =
            $"Water Days Reamining: {FormatDays(simulation.GetWaterDaysRemaining())}";
        
        gameDayText.text =
            $"Game Day: {simulation.CurrentDay}";

        statusText.text =
            simulation.IsStarving() ? "COLONY STARVING" : "COLONY HEALTHY";
    
    }

    private string FormatDays(float days)
    {
        if (float.IsPositiveInfinity(days))
        {
            return "Infinity";
        }

        return days.ToString("F1");
    }
}
