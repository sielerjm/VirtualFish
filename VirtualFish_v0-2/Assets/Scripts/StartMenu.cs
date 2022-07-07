using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu: MonoBehaviour
{
    public GameObject flashText;
    [SerializeField] bool panelOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("flashTheText", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!checkPanelOpen() && Input.GetMouseButtonUp(0))
            SceneManager.LoadScene("Main");

    }

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
        {
            flashText.SetActive(false);
        }
        else
        {
            flashText.SetActive(true);
        }

    }

    public bool checkPanelOpen()
    {
        return panelOpen;
    }

    public void setPanelOpen()
    {
        if (panelOpen){
            panelOpen = false;
        } else if (!panelOpen)
        {
            panelOpen = true;
        }
        
    }
}
