using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TileGenerator : MonoBehaviour
{
    public int rows, columns;
    public GameObject[,] gridArray;

    public GameObject tilePrefab;

    private void Start()
    {
        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2((500 / rows), (500 / columns));
        gridArray = new GameObject[rows, columns];

    }

}
