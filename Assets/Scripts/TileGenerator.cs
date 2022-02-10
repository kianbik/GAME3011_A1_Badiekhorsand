using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TileGenerator : MonoBehaviour
{
    public int rows, columns;
    public GameObject[,] gridArray;
    public int maxValue;
    public GameObject tilePrefab;
   public GameController gameController;
     void Start()
    {
        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2((500 / rows), (500 / columns));
        gridArray = new GameObject[rows, columns];
        CreateGrid();
    }

    public void CreateGrid()
    {

        for (int rowToCreate =0; rowToCreate < rows; rowToCreate++)
        {

            for(int columnsToCreate = 0; columnsToCreate < columns; columnsToCreate++)
            {

                GameObject grid = (GameObject)Instantiate(tilePrefab, gameObject.transform);
                TileScript tile = grid.GetComponent<TileScript>();
                gridArray[rowToCreate, columnsToCreate] = grid;
                tile.row = rowToCreate;
                tile.column = columnsToCreate;
                tile.tileGenerator = gameObject.GetComponent<TileGenerator>();

            }

        }
        foreach( GameObject tilesCreated in gridArray)
        {
            TileScript tileToAssing = tilesCreated.GetComponent<TileScript>();


            if (tileToAssing.row > 0)

                tileToAssing.aboveTile = gridArray[tileToAssing.row - 1, tileToAssing.column];
            

            // left tile
            if (tileToAssing.column > 0)

                tileToAssing.leftTile = gridArray[tileToAssing.row, tileToAssing.column - 1];
            

            // right tile
            if (tileToAssing.column < columns - 1)

                tileToAssing.rightTile = gridArray[tileToAssing.row, tileToAssing.column + 1];

            

            // below tile
            if (tileToAssing.row < rows - 1)

                tileToAssing.belowTile = gridArray[tileToAssing.row + 1, tileToAssing.column];



        }
            RandomizeOres();
    }

    public void RandomizeOres()
    {

        int NumberOfMaxResourceTiles = Random.Range(1, 4);
        for (int i = 0; i < NumberOfMaxResourceTiles; i++)
        {

            AddValueToOres();
        }



    }
    public void AddValueToOres()
    {

        int randomRow = Random.Range(0, rows - 1);
        int randomColumn = Random.Range(0, columns - 1);
        TileScript tileCreated = gridArray[randomRow, randomColumn].GetComponent<TileScript>();
        if (tileCreated.oreValue == 0)
            tileCreated.oreValue = maxValue;
        for (int rowsCreated = 0; rowsCreated < rows; rowsCreated++)
        {
            for (int columnsCreated = 0; columnsCreated < columns; columnsCreated++)
            {
                if (rowsCreated >= randomRow - 1 && rowsCreated <= randomRow + 1)
                {
                    if (columnsCreated >= randomColumn - 1 && columnsCreated <= randomColumn + 1)
                    {


                        TileScript tileChecker = gridArray[rowsCreated, columnsCreated].GetComponent<TileScript>();
                        if (tileChecker.oreValue < (maxValue / 2))
                            tileChecker.oreValue = (maxValue / 2);


                    }
                }
            }
        }
        for (int rowsCreated = 0; rowsCreated < rows; rowsCreated++)
        {
            for (int columnsCreated = 0; columnsCreated < columns; columnsCreated++)
            {
                if (rowsCreated >= randomRow - 2 && rowsCreated <= randomRow + 2)
                {
                    if (columnsCreated >= randomColumn - 2 && columnsCreated <= randomColumn + 2)
                    {


                        TileScript tileChecker = gridArray[rowsCreated, columnsCreated].GetComponent<TileScript>();
                        if (tileChecker.oreValue < (maxValue / 4))
                            tileChecker.oreValue = (maxValue / 4);


                    }
                }
            }
        }
    }
    public void Scan(int x , int y)
    {
        if (GameController.scanRemaining > 0)
        {
            GameController.scanRemaining--;
            for (int rowsCreated = 0; rowsCreated < rows; rowsCreated++)
            {
                for (int columnsCreated = 0; columnsCreated < columns; columnsCreated++)
                {
                    if (rowsCreated >= x - 1 && rowsCreated <= x + 1)
                    {
                        if (columnsCreated >= y - 1 && columnsCreated <= y + 1)
                        {
                            TileScript tileScanned = gridArray[rowsCreated, columnsCreated].GetComponent<TileScript>();
                            tileScanned.SetColor();
                            gameController.ShowMessage("Scanned");
                        }
                    }
                }

            }
        }
        else
           gameController.ShowMessage ("Oops, No Scan Remaining :(");

    }
    public void Extract(int x, int y)
    {
        if (GameController.extractremaining > 0)
        {
            GameController.extractremaining--;
           
            for (int rowsCreated = 0; rowsCreated < rows; rowsCreated++)
            {
                for (int columnsCreated = 0; columnsCreated < columns; columnsCreated++)
                {
                    if (rowsCreated >= x - 1 && rowsCreated <= x + 1)
                    {
                        if (columnsCreated >= y - 1 && columnsCreated <= y + 1)
                        {
                            TileScript tileScanned = gridArray[rowsCreated, columnsCreated].GetComponent<TileScript>();
                            tileScanned.Extract();
                            gameController.ShowMessage("Extracted");
                        }
                    }
                   
                }

            }
        }
        else
        gameController.ShowMessage("Oops, No Extraction Remaining :(");


    }


}
