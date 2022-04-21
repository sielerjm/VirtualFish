using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Backgrounds : MonoBehaviour
{
    public Image image;
    [SerializeField] float tankDirtyLevel = 0f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        InvokeRepeating("UpdateTankDirtyLevel", 1.0f, 1.0f);
    }

    private void Update()
    {
        SetBackgroundColor();
    }

    public float GetTankDirtyLevel()
    {
        return tankDirtyLevel;
    }

    public void SetTankDirtyLevel(float value)
    {
        tankDirtyLevel = value;
    }

    public void UpdateTankDirtyLevel()
    {
        if(tankDirtyLevel < .5f)
        {
            tankDirtyLevel += 0.005f;
        }
    }

    void SetBackgroundColor()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, tankDirtyLevel);
    }


}

