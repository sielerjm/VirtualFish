using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    int age = 0;
    public float fillFraction;
    [SerializeField] float timePassed = 55f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

        //Debug.Log(Mathf.RoundToInt(timePassed % 60)); // TEST

        if(Mathf.RoundToInt(timePassed % 60) == 0)
        {
            SetAge(Mathf.RoundToInt(timePassed / 60));
        }
        
    }

    void UpdateTimer()
    {
        timePassed += Time.deltaTime;
        fillFraction = (timePassed % 60) / 60;
    }

    public float GetTimePassed()
    {
        return timePassed;
    }

    public void SetAge(int value)
    {
        age = value; 
    }

    public int GetAge()
    {
        return age;
    }
}
