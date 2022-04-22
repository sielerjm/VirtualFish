using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    [Header("Metrics")]
    [SerializeField] TextMeshProUGUI healthScoreText;
    [SerializeField] TextMeshProUGUI happyScoreText;
    [SerializeField] TextMeshProUGUI hungerScoreText;
    Metrics metrics;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI moneyText;
    int birthday = 0;
    Timer timer;


    [Header("ProgressBar")]
    [SerializeField] Slider healthBar;
    [SerializeField] Slider happyBar;
    [SerializeField] Slider hungerBar;

    [Header("Backgrounds")]
    Backgrounds backgrounds;

    [Header("Pathogens")]
    [SerializeField] bool bacteriaPresent = false;
    [SerializeField] Canvas bacteria;
    [SerializeField] bool virusPresent = false;
    [SerializeField] Canvas virus;
    [SerializeField] bool fungusPresent = false;
    [SerializeField] Canvas fungus;
    [SerializeField] bool algaePresent = false;
    [SerializeField] Canvas algae;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        metrics = FindObjectOfType<Metrics>();
        backgrounds = FindObjectOfType<Backgrounds>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeStatusBars();
        InvokeRepeating("UpdateHungerValue", 1.0f, 1.0f);
        InvokeRepeating("UpdateHappyValue", 1.0f, 1.0f);
        InvokeRepeating("UpdateHealthValue", 1.0f, 1.0f);
        InvokeRepeating("UpdateParasites", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMetricText();
        UpdateStatusBars();
        UpdateMoney();
    }

    void InitializeStatusBars()
    {
        healthBar.maxValue = metrics.GetMaxMetric();
        healthBar.value = metrics.GetHealthScore();

        happyBar.maxValue = metrics.GetMaxMetric();
        happyBar.value = metrics.GetHappyScore();

        hungerBar.maxValue = metrics.GetMaxMetric();
        hungerBar.value = metrics.GetHungerScore();
    }


    void UpdateMetricText()
    {
        healthScoreText.text = "Health: " + Mathf.RoundToInt(metrics.GetHealthScore()); //+ "%";
        happyScoreText.text = "Happy: " + Mathf.RoundToInt(metrics.GetHappyScore());
        hungerScoreText.text = "Hunger: " + Mathf.RoundToInt(metrics.GetHungerScore());

        ageText.text = "" + timer.GetAge();
        moneyText.text = "$" + timer.GetMoney();

        timerImage.fillAmount = timer.fillFraction;
    }

    void UpdateHungerValue()
    {
        if(metrics.GetHungerScore() > 0)
        {
            metrics.SetHungerScore((float)-(.5f)); 
        }
        
    }

    void UpdateHappyValue()
    {
        if (metrics.GetHappyScore() > 0)
        {
            if (!bacteriaPresent || !virusPresent || !fungusPresent)
            {
                metrics.SetHappyScore((float)-(.25f));
            }
            else
            {
                metrics.SetHappyScore((float)-(.5f));
            }
             
        }

    }

    void UpdateHealthValue()
    {
        if (metrics.GetHealthScore() > 0)
        {
            if (!bacteriaPresent || !virusPresent || !fungusPresent)
            {
                metrics.SetHealthScore((float)-(2f * backgrounds.GetTankDirtyLevel()));
            }
            else
            {
                metrics.SetHealthScore((float)-(3f * backgrounds.GetTankDirtyLevel()));
            }
            
        }

    }

    void UpdateStatusBars()
    {
        //healthBar.maxValue = metrics.GetMaxMetric();
        healthBar.value = metrics.GetHealthScore();

        //happyBar.maxValue = metrics.GetMaxMetric();
        happyBar.value = metrics.GetHappyScore();

        //hungerBar.maxValue = metrics.GetMaxMetric();
        hungerBar.value = metrics.GetHungerScore();
    }

    void UpdateParasites()
    {
        // 1 in 60 chance of seeing parasites
        int r = Random.Range(0, 240);

        Debug.Log("random is: " + r);

        if (r == 0)  // If rand number is equal to 0, then parasites spawn
        {
            bacteriaPresent = true;
            bacteria.gameObject.SetActive(true);
            bacteriaPresent = false;
        } else if (r == 61)
        {
            // Virus
            virusPresent = true;
            virus.gameObject.SetActive(true);
            virusPresent = false;
        }
        else if (r == 120)
        {
            // Fungus
            fungusPresent = true;
            fungus.gameObject.SetActive(true);
            fungusPresent = false;
        }
        else if (r == 180)
        {
            // Fungus
            algaePresent = true;
            algae.gameObject.SetActive(true);
            algaePresent = false;
        }
    }

    void UpdateMoney()
    {
        if (birthday != timer.GetAge() & Mathf.RoundToInt(timer.GetTimePassed() % 60) == 0)
        {
            Debug.Log("Happy Birthday");
            timer.SetMoney(50);
            birthday += 1;
        } else
        {
        }
    }

}
