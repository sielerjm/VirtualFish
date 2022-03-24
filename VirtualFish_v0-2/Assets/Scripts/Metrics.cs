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

        if (healthScore > 100)
        {
            healthScore = 100;
        }
        else if (healthScore < 0)
        {
            healthScore = 0;
        }
    }

    public int GetHappyScore()
    {
        return happyScore;
    }

    public void SetHappyScore(int increment)
    {
        happyScore = (happyScore += increment) / 100;

        if (happyScore > 100)
        {
            happyScore = 100;
        }
        else if (happyScore < 0)
        {
            happyScore = 0;
        }
    }

    public int GetHungerScore()
    {
        return hungerScore;
    }

    public void SetHungerScore(int increment)
    {
        hungerScore += increment;

        if (hungerScore > 100)
        {
            hungerScore = 100;
        } else if (hungerScore < 0)
        {
            hungerScore = 0;
        }
    }

    public int GetMaxMetric()
    {
        return maxMetric;
    }

}
