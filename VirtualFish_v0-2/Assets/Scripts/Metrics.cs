using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metrics : MonoBehaviour
{
    int healthScore = 100;
    int happyScore = 100;
    int hungerScore = 100;
    int maxMetric = 100;

    public int GetHealthScore()
    {
        return healthScore;
    }

    public void SetHealthScore(int increment)
    {
        healthScore = (healthScore += increment)/100;
    }

    public int GetHappyScore()
    {
        return happyScore;
    }

    public void SetHappyScore(int increment)
    {
        happyScore = (happyScore += increment) / 100;
    }

    public int GetHungerScore()
    {
        return hungerScore;
    }

    public void SetHungerScore(int increment)
    {
        hungerScore = (hungerScore += increment) / 100;
    }

    public int GetMaxMetric()
    {
        return maxMetric;
    }

}
