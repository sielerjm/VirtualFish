using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    //You don't need static for this variable
    public int score = 0;
    [SerializeField] public TextMeshProUGUI scoreText;

    public void Update()
    {
        //scoreText.text = "Your fish lived to " + DisplayScore().ToString() + " days old!";
        int age = DisplayScore();

        if (age == 1)
        {
            scoreText.text = "Your fish lived to " + age.ToString() + " day old!";
        }
        else
        {
            scoreText.text = "Your fish lived to " + age.ToString() + " days old!";
        }

    }

    public int DisplayScore()
    {
        return PlayerPrefs.GetInt("Score");
    }


}
