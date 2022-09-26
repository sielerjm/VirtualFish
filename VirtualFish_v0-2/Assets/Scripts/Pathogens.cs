using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathogens : MonoBehaviour
{
    [Header("Pathogens")]
    [SerializeField] bool bacteriaPresent = false;
    [SerializeField] Canvas bacteria;
    [SerializeField] bool virusPresent = false;
    [SerializeField] Canvas virus;
    [SerializeField] bool fungusPresent = false;
    [SerializeField] Canvas fungus;
    [SerializeField] bool algaePresent = false;
    [SerializeField] Canvas algae;

    [Header("ParticleEffects")]
    [SerializeField] ParticleSystem bacteriaParticleEffect;
    [SerializeField] ParticleSystem virusParticleEffect;
    [SerializeField] ParticleSystem fungusParticleEffect;
    [SerializeField] ParticleSystem algaeParticleEffect;

    [Header("Audio")]
    [SerializeField] AudioSource pathogenWarning;


    Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateParasites", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();

    }

    public bool GetPathogenStatus(int pathogen)
    {
        //Debug.Log("Checking pathogen(" + pathogen + ") status.");
        if (pathogen == 0)  // Bacteria
        {
            return bacteriaPresent;
        }
        else if (pathogen == 1)  // Virus
        {
            return virusPresent;
        }
        else if (pathogen == 2)  // Fungus
        {
            return fungusPresent;
        }
        else if (pathogen == 3)  // Algae
        {
            return algaePresent;
        }
        else
        {
            return false;  // Invalid catch all
        }

    }

    public void SetPathogenStatus(int pathogen)
    {
        //Debug.Log("Checking pathogen(" + pathogen + ") status.");
        if (pathogen == 0)  // Bacteria
        {
            bacteriaPresent = false;
            bacteriaParticleEffect.Stop();
        }
        else if (pathogen == 1)  // Virus
        {
            virusPresent = false;
            virusParticleEffect.Stop();
        }
        else if (pathogen == 2)  // Fungus
        {
            fungusPresent = false;
            fungusParticleEffect.Stop();
        }
        else if (pathogen == 3)  // Algae
        {
            algaePresent = false;
            algaeParticleEffect.Stop();
        }

    }

    void UpdateParasites()
    {
        if (!timer.GetPanelOpen())
        {
            // 1 in 60 chance of seeing parasites
            int r = Random.Range(0, 240);

            //Debug.Log("random is: " + r);

            if (r == 0)  // If rand number is equal to 0, then parasites spawn
            {
                bacteriaPresent = true;
                Debug.Log("Bacteria are present");
                bacteria.gameObject.SetActive(true);
                bacteriaParticleEffect.Play();
                pathogenWarning.Play();
                //bacteriaPresent = false;
            }
            else if (r == 61)
            {
                // Virus
                virusPresent = true;
                Debug.Log("Virus are present");
                virus.gameObject.SetActive(true);
                virusParticleEffect.Play();
                pathogenWarning.Play();
                //virusPresent = false;
            }
            else if (r == 120)
            {
                // Fungus
                fungusPresent = true;
                Debug.Log("Fungus are present");
                fungus.gameObject.SetActive(true);
                fungusParticleEffect.Play();
                pathogenWarning.Play();
                //fungusPresent = false;
            }
            else if (r == 180)
            {
                // Algae
                algaePresent = true;
                Debug.Log("Algae are present");
                algae.gameObject.SetActive(true);
                algaeParticleEffect.Play();
                pathogenWarning.Play();
                //algaePresent = false;
            }
        }

    }
}
