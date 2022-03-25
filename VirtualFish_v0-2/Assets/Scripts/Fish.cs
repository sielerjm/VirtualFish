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
    Timer timer;

    [Header("ProgressBar")]
    [SerializeField] Slider healthBar;
    [SerializeField] Slider happyBar;
    [SerializeField] Slider hungerBar;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        metrics = FindObjectOfType<Metrics>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeStatusBars();
        InvokeRepeating("UpdateHungerValue", 1.0f, 1.0f);
        InvokeRepeating("UpdateHappyValue", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMetricText();

        
        //if(Mathf.RoundToInt(timer.GetTimePassed()) % 1 == 0)
        //{
        //    Debug.Log("Time Passed: " + Mathf.RoundToInt(timer.GetTimePassed()));  // TEST
        //}

        UpdateStatusBars();
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

        timerImage.fillAmount = timer.fillFraction;
    }

    void UpdateHungerValue()
    {
        if(metrics.GetHungerScore() > 0)
        {
            metrics.SetHungerScore((float)-0.5f);
        }
        
    }

    void UpdateHappyValue()
    {
        if (metrics.GetHappyScore() > 0)
        {
            metrics.SetHappyScore((float)-0.25f);
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
}
