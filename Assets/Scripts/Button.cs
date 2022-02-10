using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    public GameObject GameCanvas;
    public GameObject StartCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 public void onClick()
    {
        GameCanvas.SetActive(true);
        StartCanvas.SetActive(false);
    }
}
