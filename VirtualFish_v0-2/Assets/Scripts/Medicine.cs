using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [Header("Fish")]
    Fish fish;

    [Header("Metrics")]
    [SerializeField] float healthValue = 10f;
    [SerializeField] float happyValue = 5f;
    [SerializeField] float hungerValue = 0f;

    [Header("Consequences")]
    [SerializeField] float decreaseHealthValue = -5f;
    [SerializeField] float decreaseHappyValue = -5f;
    [SerializeField] float decreaseHungerValue = -5f;
    [SerializeField] GameObject Metrics;
    Cooldown cooldown;

    [Header("Pathogens")]
    //Pathogens pathogens;
    [SerializeField] GameObject Pathogens;
    [SerializeField] Canvas pathogenCanvas;
    [SerializeField] int pathogenID; // 0 = bacteria, 1 = virus, 2 = fungus, 3 = algae
    [SerializeField] int medicationID; // 0 = antibact, 1 = antivir, 2 = antifung, 3 = antialg
    [SerializeField] bool pathogenPresent = false;





    // Start is called before the first frame update
    void Start()
    {
        //metrics = GetComponent<Metrics>();
        cooldown = GetComponent<Cooldown>();
        fish = GetComponent<Fish>();
        //pathogens = GetComponent<Pathogens>();

        // Get pathogen status

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Cooldown status from Medicine.cs: " + cooldown.GetIsCooldown());
        UpdatePathogenStatus();
    }

    public void UpdateMetrics()
    {
        Debug.Log("Medication button was pressed");

        //if (!cooldown.GetIsCooldown())
        //{

            Debug.Log("No Cooldown in medicine.cs");


            if (pathogenPresent)  // If pathogen present
            {
                Debug.Log("Pathogen present in medicine.cs, applying meds");

                if(medicationID == pathogenID)
                {
                    pathogenPresent = false;
                    pathogenCanvas.gameObject.SetActive(false);
                    Pathogens.GetComponent<Pathogens>().SetPathogenStatus(pathogenID);

                    Debug.Log("Update health: " + healthValue +
                        " Update happy: " + happyValue +
                        " Update hunger: " + hungerValue);

                    Metrics.GetComponent<Metrics>().SetHealthScore(healthValue);
                    Metrics.GetComponent<Metrics>().SetHappyScore(happyValue);
                    Metrics.GetComponent<Metrics>().SetHungerScore(hungerValue);
                }
                else
                {
                    decreaseMetrics();
                }

                
            }
            else  // If pathogen not present
            {
                decreaseMetrics();
            }


        //}
        //Metrics.GetComponent<Metrics>().SetHealthScore(healthValue);
        //Metrics.GetComponent<Metrics>().SetHungerScore(happyValue);
        //Metrics.GetComponent<Metrics>().SetHealthScore(hungerValue);
    }

    void decreaseMetrics()
    {
        Debug.Log("Improper action (mismedicated/overfed/etc.!");
        Metrics.GetComponent<Metrics>().SetHealthScore(decreaseHealthValue);
        Metrics.GetComponent<Metrics>().SetHappyScore(decreaseHappyValue);
        Metrics.GetComponent<Metrics>().SetHungerScore(decreaseHungerValue);
    }

    void UpdatePathogenStatus()
    {
        pathogenPresent = Pathogens.GetComponent<Pathogens>().GetPathogenStatus(pathogenID);
        //Debug.Log("Pathogen(" + pathogenID + ") status from Medicine.cs: " + pathogenPresent);  // print the status of pathogen present or absent

    }


}
