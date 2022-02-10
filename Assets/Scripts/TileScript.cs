using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TileScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
   
    public int oreValue;
    public Image tileImage;

    public bool Revealed;

    public int row;
    public int column;
    public TileGenerator tileGenerator;
   
    // Not used for current implementation, but remaining in for potential further functionality! 
    public GameObject aboveTile;
    public GameObject leftTile;
    public GameObject rightTile;
    public GameObject belowTile;
    // Start is called before the first frame update
    void Start()
    {
        tileImage = gameObject.GetComponent<Image>();
        tileImage.color = Color.magenta;
    }
    void Update()
    {if(Revealed)
        SetColor();

        if (GameController.extractremaining ==0)
        {
            Revealed = true;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // Send an event to scr_ExtractionGridGenerator with the row and column of the clicked tile. 
        if (GameController.scanMode)
        {
            tileGenerator.Scan(row, column);
        }
        else
        {
            tileGenerator.Extract(row, column);
          

        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!Revealed)
        tileImage.color = Color.green;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Revealed)
            tileImage.color = Color.magenta;

    }
    public void SetColor()
    {
        if (oreValue == 400)
            gameObject.GetComponent<Image>().color = Color.white;

        else if (oreValue == 200)
            gameObject.GetComponent<Image>().color = Color.yellow;

        else if (oreValue == 100)
            gameObject.GetComponent<Image>().color = Color.red;

        else
        {
            gameObject.GetComponent<Image>().color = Color.black;
            oreValue = 0;
        }

        Revealed = true;
       
    }
    public void Extract()
    {

        GameController.score += oreValue;
        if (oreValue == 100)
            oreValue = 0;
        else
        oreValue = oreValue / 2;
        Revealed = true;

    }
}
