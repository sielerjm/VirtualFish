using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooldown : MonoBehaviour
{
    [SerializeField] Image imageCooldown;
    [SerializeField] TMP_Text textCooldown;

    [SerializeField] private bool isCooldown = false;
    [SerializeField] private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;

    [SerializeField] ParticleSystem particleEffect;


    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

    }

    void Update()
    {
        if (isCooldown)
        {
            // Debug.Log("Cooldown = true");
            ApplyCooldown();
        }
        else
        {
            //Debug.Log("Cooldown = false");
        }
        
    }

    public void ApplyCooldown() # test
    {
        // subtract time since last called
        cooldownTimer -= Time.deltaTime;
        

        // Debug.Log(cooldownTimer);

        if (cooldownTimer <= 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
            cooldownTimer = 0.0f;

             Debug.Log("Cooldown = " + isCooldown);
        }
        else
        {
            Debug.Log("Cooldown = " + isCooldown);

            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;

        }
    }

    public void UseAction()
    {
        //if (isCooldown)
        //{
        //    // Add feedback if user clicked action while CD in use
        //    Debug.Log("Wait for cooldown!");


        //} else
        //{
            // ABILITIES OR ACTIONS go here

            particleEffect.Play();

            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        //}
    }

    public bool GetIsCooldown()
    {
        return isCooldown;
    }

}
