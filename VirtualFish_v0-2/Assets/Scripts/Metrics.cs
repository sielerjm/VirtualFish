using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metrics : MonoBehaviour
{
    float healthScore = 100;
    float happyScore = 100;
    float hungerScore = 100;
    float maxMetric = 100;

    public float GetHealthScore()
    {
        return healthScore;
    }

    public void SetHealthScore(float increment)
    {
        healthScore += increment;

        if (healthScore > 100)
        {
            healthScore = 100;
        }
        else if (healthScore < 0)
        {
            healthScore = 0;
        }
    }

    public float GetHappyScore()
    {
        return happyScore;
    }

    public void SetHappyScore(float increment)
    {
        happyScore += increment;

        if (happyScore > 100)
        {
            happyScore = 100;
        }
        else if (happyScore < 0)
        {
            happyScore = 0;
        }
    }

    public float GetHungerScore()
    {
        return hungerScore;
    }

    public void SetHungerScore(float increment)
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

    public float GetMaxMetric()
    {
        return maxMetric;
    }

}
