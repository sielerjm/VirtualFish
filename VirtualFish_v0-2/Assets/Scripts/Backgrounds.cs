using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Backgrounds : MonoBehaviour
{
    public Image image;
    [SerializeField] bool cleanTank = false;
    [SerializeField] float tankDirtyLevel = 0f;

    private void Awake()
    {
        image = FindObjectOfType<Image>();
        //var tempColor = image.color;
        //tempColor.a = 0f;
        //image.color = tempColor;
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
        tankDirtyLevel += 0.005f;
    }

    void SetBackgroundColor()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, tankDirtyLevel);
    }


}

