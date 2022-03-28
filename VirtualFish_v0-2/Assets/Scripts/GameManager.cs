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
        fish.gameObject.SetActive(true);
    }

    private void Awake()
    {
        fish = FindObjectOfType<Fish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
