using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPanels : MonoBehaviour
{
    //[Header("Canvases")]  // Could be better as a list of canvases
    [SerializeField] GameObject foodCanvas;
    [SerializeField] GameObject tankCanvas;
    [SerializeField] GameObject careCanvas;
    [SerializeField] GameObject learnCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPanelsOpen();
    }

    public bool CheckPanelsOpen()
    {
        if (foodCanvas.activeSelf || tankCanvas.activeSelf ||
            careCanvas.activeSelf || learnCanvas.activeSelf)
        {
            return true;  // Returns false if none are active
        }
        else
        {
            return false;  // Returns true if one or more are active
        }
    }
}
