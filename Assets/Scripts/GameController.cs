using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static bool scanMode = false;

    public static int score = 0;
    public static int scanRemaining = 5;
    public static int extractremaining = 3;

    public Toggle scanModeToggle;
    public Toggle extractToggle;


    public Text scoreText;
    public Text scanRemainingText;
    public Text extractRemainingText;
    public Text messageText;



    public void Start()
    {
  

    }
    public void Update()
    {
      scanMode = scanModeToggle.isOn;

        scoreText.text = "SCORE: " + score.ToString();
        scanRemainingText.text = "SCANS REMAINING: " + scanRemaining.ToString();
        extractRemainingText.text = "EXTRACTS REMAINING: " + extractremaining.ToString();

    }
    public void ShowMessage(string messageToDisplay)
    {
        
        messageText.text = messageToDisplay;
    }
    public  void Scanned()
    {
        scanRemaining--;
       // messageText.text = "Tile Scanned";
    }
    public  void Extracted()
    {
        extractremaining--;
       //messageText.text = "Tile Extracted";
    }
}
