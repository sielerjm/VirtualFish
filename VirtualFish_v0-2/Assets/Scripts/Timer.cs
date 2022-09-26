using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    int age = 0;
    int money = 50;
    [SerializeField] bool panelOpen = false;
    public float fillFraction;
    [SerializeField] float timePassed = 0f;
    [SerializeField] float timeMultiplier = 1f;

    CheckPanels checkPanels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        checkPanels = FindObjectOfType<CheckPanels>();
    }

    // Update is called once per frame
    void Update()
    {
        panelOpen = checkPanels.CheckPanelsOpen();
        UpdateTimer();

        //Debug.Log(Mathf.RoundToInt(timePassed % 60)); // TEST

        if(Mathf.RoundToInt(timePassed % 60) == 0)
        {
            SetAge(Mathf.RoundToInt(timePassed / 60));
            
        }
        
    }

    void UpdateTimer()
    {
        if (!panelOpen)
        {
            timePassed += (Time.deltaTime * timeMultiplier);
            fillFraction = (timePassed % 60) / 60;
        }

    }

    public float GetTimePassed()
    {
        return Mathf.RoundToInt(timePassed);
    }

    public float GetTimePassedFloat()
    {
        return Mathf.RoundToInt(timePassed);
    }

    public void SetAge(int value)
    {
        age = value; 
    }

    public int GetAge()
    {
        return age;
    }

    public void SetMoney(int value)
    {
        money += value;
    }

    public int GetMoney()
    {
        return money;
    }

    public void SetPanelOpen(bool value)
    {
        panelOpen = value;
    }

    public bool GetPanelOpen()
    {
        return panelOpen;
    }

}
