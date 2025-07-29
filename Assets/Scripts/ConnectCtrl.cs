using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectCtrl : MonoBehaviour
{
    public static ConnectCtrl I;
    private void Awake()
    {
        I = this;
    }

    public bool CheckRowX(Cell[, ] grid,Cell cell1, Cell cell2)
    {
        int startCol = Mathf.Min(cell1.Col, cell2.Col);
        int endCol = Mathf.Max(cell1.Col, cell2.Col);
        int rowCheck = cell1.Row;
        for(int i = startCol + 1; i <= endCol; i++)
        {
            if (grid[rowCheck, i].ID == -1 && grid[rowCheck, i].ID != cell2.ID)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckColY(Cell[, ] grid, Cell cell1, Cell cell2)
    {
        int startRow = Mathf.Min(cell1.Row, cell2.Row);
        int endRow = Mathf.Max(cell1.Row, cell2.Row);
        int colCheck = cell1.Col;
        for (int i = startRow + 1; i <= endRow; i++)
        {
            if (grid[i, colCheck].ID == -1 && grid[i, colCheck].ID != cell2.ID)
            {
                return false;
            }
        }
        return true;
    }
}
