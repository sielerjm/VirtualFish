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
    }

    // Update is called once per frame
    void Update()
    {
        healthScoreText.text = "Health: " + metrics.GetHealthScore(); //+ "%";
        happyScoreText.text = "Happy: " + metrics.GetHappyScore();
        hungerScoreText.text = "Hunger: " + metrics.GetHungerScore();

        ageText.text = "" + timer.GetAge();

        timerImage.fillAmount = timer.fillFraction;
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
}
