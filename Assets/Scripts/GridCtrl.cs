using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCtrl : MonoBehaviour
{
    public Cell CellPrefab;
    [Header("GRID CONFIG")]
    public Vector2 CellSize;
    public int row;
    public int col;

    private void Start()
    {
        GenerateGrid(row, col);
    }

    public void GenerateGrid(int Row, int Col)
    {
        for(int x = 0; x < Row; x++)
        {
            for(int y = 0; y < Col; y++)
            {
                float offSetX = (CellSize.x * (Col - 1)) / 2;
                float offSetY = (CellSize.x * (Row - 1)) / 2;


                float posX = (y * CellSize.y) - offSetX;
                float posY = (x * CellSize.x) - offSetY;
                Vector2 pos = new Vector2(posX, posY);

                Cell cell = Instantiate(CellPrefab, transform);
                cell.SetPos(pos);
                cell.UpdateSortLayer();
                cell.name = $"({x}, {y})";
            }
        }
    }
}
