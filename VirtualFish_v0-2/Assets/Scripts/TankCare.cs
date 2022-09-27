using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankCare : MonoBehaviour
{
    [Header("Metrics")]
    [SerializeField] float healthValue = 1f;
    [SerializeField] float happyValue = 1f;
    [SerializeField] float hungerValue = 1f;

    [Header("Consequences")]
    [SerializeField] float decreaseHealthValue = -5f;
    [SerializeField] float decreaseHappyValue = -5f;
    [SerializeField] float decreaseHungerValue = 0f;

    [SerializeField] GameObject Metrics;
    [SerializeField] GameObject Backgrounds;
    //Backgrounds backgrounds;
    //Cooldown cooldown;


    // Start is called before the first frame update
    void Start()
    {
        //metrics = GetComponent<Metrics>();
        //cooldown = GetComponent<Cooldown>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Cooldown status from Hunger.cs: " + cooldown.GetIsCooldown());
    }

    public void UpdateMetrics()
    {
        Debug.Log("Tank Dirty Level: "+ Backgrounds.GetComponent<Backgrounds>().GetTankDirtyLevel());

        if ((Backgrounds.GetComponent<Backgrounds>().GetTankDirtyLevel()) > 0.01f)
        {
            Debug.Log("Update health: " + healthValue +
                    " Update happy: " + happyValue +
                    " Update hunger: " + hungerValue);

            Metrics.GetComponent<Metrics>().SetHealthScore(healthValue);
            Metrics.GetComponent<Metrics>().SetHappyScore(happyValue);
            Metrics.GetComponent<Metrics>().SetHungerScore(hungerValue);
        }
        else
        {
            Debug.Log("Overcleaning!");
            Debug.Log("Update health: " + decreaseHealthValue +
                    " Update happy: " + decreaseHappyValue +
                    " Update hunger: " + decreaseHungerValue);

            Metrics.GetComponent<Metrics>().SetHealthScore(decreaseHealthValue);
            Metrics.GetComponent<Metrics>().SetHappyScore(decreaseHappyValue);
            Metrics.GetComponent<Metrics>().SetHungerScore(decreaseHungerValue);
        }
        //Metrics.GetComponent<Metrics>().SetHealthScore(healthValue);
        //Metrics.GetComponent<Metrics>().SetHungerScore(happyValue);
        //Metrics.GetComponent<Metrics>().SetHealthScore(hungerValue);
    }
}
