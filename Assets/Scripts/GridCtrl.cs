using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCtrl : MonoBehaviour
{
    [SerializeField] Cell cell1;
    [SerializeField] Cell cell2;

    Cell[,] grid;

    [Header("GRID CONFIG")]
    public Vector2 CellSize;
    public int row;
    public int col;

    [Header("Preference Variable")]
    [SerializeField] IconSO dataIcon;
    public Cell CellPrefab;


    private void Start()
    {
        SpawnGrid(row, col);
        GenerateDataGrid();
    }

    void SpawnGrid(int Row, int Col)
    {
        grid = new Cell[row, col];
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

                grid[x, y] = cell;

                cell.OnCellClickEvent += OnCellClickEvent;
            }
        }
    }

    void GenerateDataGrid()
    {
        int playableRows = row - 2;
        int playableCols = col - 2;

        int playableCells = playableRows * playableCols;

        //Tạo danh sách các cặp hình
        List<int> listIdCells = new List<int>();

        for (int i = 0; i < playableCells / 2; i++)
        {
            int id = Random.Range(0, dataIcon.listIcon.Length);
            listIdCells.Add(id);
            listIdCells.Add(id);
        }

        //Trộn danh sách các cặp hình
        for (int i = 0; i < listIdCells.Count; i++)
        {
            int rand = Random.Range(0, listIdCells.Count);
            (listIdCells[i], listIdCells[rand]) = (listIdCells[rand], listIdCells[i]);
        }

        //Gán vào lưới
        for (int r = 0; r < row; r++)
        {
            for(int c = 0; c < col; c++)
            {
                if (c == 0 || r == 0 || c == col - 1 || r == row - 1)
                {
                    grid[r, c].ID = -1;
                    grid[r, c].ShowUI(false);
                }
                else
                {
                    grid[r, c].ShowUI(true);
                    int id = listIdCells[0];
                    grid[r, c].ID = id;
                    listIdCells.RemoveAt(0);
                    grid[r, c].UpdateIcon(dataIcon.listIcon[id]);
                }
            }
        }
    }

    void OnCellClickEvent(Cell cellClick)
    {
        if(cell1 == null)
        {
            cell1 = cellClick;
            cell1.OnSelected();
        }
        else
        {
            if(cellClick == cell1)
            {
                ResetCell();
            }
            else
            {
                cell2 = cellClick;
                cell2.OnSelected();
                Debug.Log("Log: Check");
                ResetCell();

            }
        }
    }

    private void ResetCell()
    {
        if (cell1 != null)
        {
            cell1.UnSelect();
            cell1 = null;
        }
        if(cell2 != null)
        {
            cell2.UnSelect();
            cell2 = null;
        }
    }
}
