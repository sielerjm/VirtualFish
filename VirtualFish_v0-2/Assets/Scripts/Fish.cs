using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    [Header("Metrics")]
    [SerializeField] TextMeshProUGUI healthScoreText;
    [SerializeField] TextMeshProUGUI happyScoreText;
    [SerializeField] TextMeshProUGUI hungerScoreText;
    [SerializeField] float incrementHealth = 2f;
    [SerializeField] float incHealthMultiplier = 1.0f;
    [SerializeField] float incrementHappy = 2f;
    [SerializeField] float incHappyMultiplier = 1.0f;
    [SerializeField] float incrementHunger = 2f;
    [SerializeField] float incHungerMultiplier = 1.0f;
    Metrics metrics;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI moneyText;
    //[SerializeField] public bool panelOpen = false;
    int birthday = 0;
    [SerializeField] float updateMultiplier = 1.0f;  // Increases how often UpdateXValue is called
    Timer timer;


    [Header("ProgressBar")]
    [SerializeField] Slider healthBar;
    [SerializeField] Image healthBarFill;
    [SerializeField] Slider happyBar;
    [SerializeField] Image happyBarFill;
    [SerializeField] Slider hungerBar;
    [SerializeField] Image hungerBarFill;


    [Header("Backgrounds")]
    Backgrounds backgrounds;

    [Header("Pathogens")]
    [SerializeField] GameObject Pathogens;
    //[SerializeField] bool bacteriaPresent = false;
    //[SerializeField] Canvas bacteria;
    //[SerializeField] bool virusPresent = false;
    //[SerializeField] Canvas virus;
    //[SerializeField] bool fungusPresent = false;
    //[SerializeField] Canvas fungus;
    //[SerializeField] bool algaePresent = false;
    //[SerializeField] Canvas algae;

    [Header("Fish")]
    //bool isAlive = true;
    Animator myAnimator;

    [Header("Audio")]
    [SerializeField] AudioSource pathogenWarning;


    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        metrics = FindObjectOfType<Metrics>();
        backgrounds = FindObjectOfType<Backgrounds>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //pathogens = GetComponent<Pathogens>();

        InitializeStatusBars();
        InvokeRepeating("UpdateHungerValue", 1.0f, updateMultiplier);
        InvokeRepeating("UpdateHappyValue", 1.0f, updateMultiplier);
        InvokeRepeating("UpdateHealthValue", 1.0f, updateMultiplier);
        //InvokeRepeating("UpdateParasites", 1.0f, updateMultiplier);

        PlayerPrefs.SetInt("Score", 0);

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMetricText();
        UpdateStatusBars();
        UpdateAge();
        PlayerPrefs.SetInt("Score", timer.GetAge());

        Die();

        //lerpSpeed = 3f * Time.deltaTime;
        //HealthBarFiller();
        //ColorChanger();
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
        //if (!timer.GetPanelOpen())
        //{
            healthScoreText.text = "Health: " + Mathf.RoundToInt(metrics.GetHealthScore()); //+ "%";
            happyScoreText.text = "Happy: " + Mathf.RoundToInt(metrics.GetHappyScore());
            hungerScoreText.text = "Hunger: " + Mathf.RoundToInt(metrics.GetHungerScore());

            ageText.text = "" + timer.GetAge();
            //moneyText.text = "$" + timer.GetMoney();

            timerImage.fillAmount = timer.fillFraction;
        //}

    }

    void UpdateHungerValue()
    {
        if (!timer.GetPanelOpen())
        {
            if (metrics.GetHungerScore() < 100)
            {
                metrics.SetHungerScore(incrementHunger * incHungerMultiplier);
            }
        }

    }

    void UpdateHappyValue()
    {
        if(!timer.GetPanelOpen())
        {
            if (metrics.GetHappyScore() > 0)
            {
                //if (!bacteriaPresent || !virusPresent || !fungusPresent || !algaePresent)
                if (!Pathogens.GetComponent<Pathogens>().GetPathogenStatus(0) || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(1)
                    || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(2) || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(3))
                {
                    metrics.SetHappyScore((float)-(incrementHappy));
                }
                else
                {
                    metrics.SetHappyScore((float)-(2 * incrementHappy * incHappyMultiplier));
                }

            }
        }
        

    }

    void UpdateHealthValue()
    {
        if (!timer.GetPanelOpen())
        {
            if (metrics.GetHealthScore() > 0)
            {
                if (!Pathogens.GetComponent<Pathogens>().GetPathogenStatus(0) || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(1)
                    || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(2) || !Pathogens.GetComponent<Pathogens>().GetPathogenStatus(3))
                {
                    metrics.SetHealthScore((float)-(incrementHealth * incHealthMultiplier + backgrounds.GetTankDirtyLevel()));
                }
                else
                {
                    metrics.SetHealthScore((float)-(2 * incrementHealth * incHealthMultiplier + backgrounds.GetTankDirtyLevel()));
                }

            }
        }
          
    }

    void UpdateStatusBars()
    {
        //healthBar.maxValue = metrics.GetMaxMetric();
        healthBar.value = metrics.GetHealthScore();
        healthBarFill.color = Color.Lerp(Color.red, Color.green, (healthBar.value/100));

        //happyBar.maxValue = metrics.GetMaxMetric();
        happyBar.value = metrics.GetHappyScore();
        happyBarFill.color = Color.Lerp(Color.red, Color.green, (happyBar.value / 100));

        //hungerBar.maxValue = metrics.GetMaxMetric();
        hungerBar.value = metrics.GetHungerScore();
        hungerBarFill.color = Color.Lerp(Color.green, Color.red, (hungerBar.value / 100));
    }

    //public bool GetPathogenStatus(int pathogen)
    //{
    //    if(pathogen == 0)  // Bacteria
    //    {
    //        return bacteriaPresent;
    //    }
    //    else if (pathogen == 1)  // Virus
    //    {
    //        return virusPresent;
    //    }
    //    else if (pathogen == 2)  // Fungus
    //    {
    //        return fungusPresent;
    //    }
    //    else if (pathogen == 3)  // Algae
    //    {
    //        return algaePresent;
    //    }
    //    else
    //    {
    //        return false;  // Invalid catch all
    //    }

    //}

    //void UpdateParasites()
    //{
    //    if (!timer.GetPanelOpen())
    //    {
    //        // 1 in 60 chance of seeing parasites
    //        int r = Random.Range(0, 240);

    //        //Debug.Log("random is: " + r);

    //        if (r == 0)  // If rand number is equal to 0, then parasites spawn
    //        {
    //            bacteriaPresent = true;
    //            Debug.Log("Bacteria are present");
    //            bacteria.gameObject.SetActive(true);
    //            pathogenWarning.Play();
    //            bacteriaPresent = false;
    //        }
    //        else if (r == 61)
    //        {
    //            // Virus
    //            virusPresent = true;
    //            Debug.Log("Virus are present");
    //            virus.gameObject.SetActive(true);
    //            pathogenWarning.Play();
    //            virusPresent = false;
    //        }
    //        else if (r == 120)
    //        {
    //            // Fungus
    //            fungusPresent = true;
    //            Debug.Log("Fungus are present");
    //            fungus.gameObject.SetActive(true);
    //            pathogenWarning.Play();
    //            fungusPresent = false;
    //        }
    //        else if (r == 180)
    //        {
    //            // Algae
    //            algaePresent = true;
    //            Debug.Log("Algae are present");
    //            algae.gameObject.SetActive(true);
    //            pathogenWarning.Play();
    //            algaePresent = false;
    //        }
    //    }
        
    //}

    void UpdateAge()
    {
        if (birthday != timer.GetAge() & Mathf.RoundToInt(timer.GetTimePassed() % 60) == 0)
        {
            Debug.Log("Happy Birthday");
            //timer.SetMoney(50);
            birthday += 1;
            
        } else
        {
        }
    }


    void Die()
    {
        if(metrics.GetHealthScore() <= 0)
        {
            //isAlive = false;
            Debug.Log("Dead!");
            //myAnimator.SetTrigger("Dead");
            SceneManager.LoadScene("EndGame");
        }
    }


}
