using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Fish fish;

    // Start is called before the first frame update
    void Start()
    {
        //fish.gameObject.SetActive(true);
    }

    private void Awake()
    {
        fish = FindObjectOfType<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayGame()
    {
        Debug.Log("Pressing Replay Game");
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Main");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ExitGame()
    {
        SceneManager.LoadScene("EndGame");
    }


}
