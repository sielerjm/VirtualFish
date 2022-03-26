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

    [Header("Parasites")]
    [SerializeField] bool parasitesPresent = false;
    [SerializeField] Canvas parasites;

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
        moneyText.text = "" + timer.GetMoney();

        timerImage.fillAmount = timer.fillFraction;
    }

    void UpdateHungerValue()
    {
        if(metrics.GetHungerScore() > 0)
        {
            metrics.SetHungerScore((float)-(0.5f)); 
        }
        
    }

    void UpdateHappyValue()
    {
        if (metrics.GetHappyScore() > 0)
        {
            if (!parasitesPresent)
            {
                metrics.SetHappyScore((float)-(0.25f));
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
            if (!parasitesPresent)
            {
                metrics.SetHealthScore((float)-(4f * backgrounds.GetTankDirtyLevel()));
            }
            else
            {
                metrics.SetHealthScore((float)-(6f * backgrounds.GetTankDirtyLevel()));
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
        int r = Random.Range(0, 100);

        Debug.Log("random is: " + r);

        if (r == 0)  // If rand number is equal to 0, then parasites spawn
        {
            parasitesPresent = true;
            parasites.gameObject.SetActive(true);
            parasitesPresent = false;
        } else
        {
            // Decrease health and happiness 
        }
    }

    void UpdateMoney()
    {
        Debug.Log(Mathf.RoundToInt(timer.GetTimePassed() % 60));
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
