using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    //Check Can Connect
    void CheckTwoPoint(Cell cell1, Cell cell2)
    {
        if(cell1.Row == cell2.Row)
        {
            if(CheckRowX(cell1.Col, cell2.Col, cell1.Row))
            {
                Debug.Log($"Cùng hàng có đường đi: {cell1.Row}");
            }
        }

        if(cell1.Col == cell2.Col)
        {

        }
    }

    //Kiểm tra giữa 2 ô trên cùng một hàng có đường đi hay không
    public bool CheckRowX(int colStart, int colEnd, int rowCheck)
    {
        int startCol = colStart;
        int endCol = colEnd;

        if(startCol > endCol)
        {
            startCol = colEnd;
            endCol = rowCheck;
        }

        //int startCol = Mathf.Min(cell1.Col, cell2.Col);
        //int endCol = Mathf.Max(cell1.Col, cell2.Col);

        for (int i = startCol + 1; i <= endCol; i++)
        {
            if (grid[rowCheck, i].ID == -1 && grid[rowCheck, i].ID != cell2.ID)
            {
                return false;
            }
        }
        return true;
    }


    //Kiểm tra giữa 2 ô trên cùng một cột có đường đi hay không
    public bool CheckColY(int rowStart, int rowEnd, int colCheck)
    {
        int startRow = rowStart;
        int endRow = rowEnd;

        if(startRow > endRow)
        {
            startRow = rowEnd;
            endRow = rowStart;
        }
        //int startRow = Mathf.Min(cell1.Row, cell2.Row);
        //int endRow = Mathf.Max(cell1.Row, cell2.Row);

        for (int i = startRow + 1; i <= endRow; i++)
        {
            if (grid[i, colCheck].ID == -1 && grid[i, colCheck].ID != cell2.ID)
            {
                return false;
            }
        }
        return true;
    }

    //Kiểm tra hình chữ nhật trong phạm vi của 2 ô có đường đi hay không
    public int CheckRectX(Cell cell1, Cell cell2)
    {
        Cell cMin = cell1;
        Cell cMax = cell2;

        if(cMin.Col > cMax.Col)
        {
            cMin = cell2;
            cMax = cell1;
        }

        for (int c = cMin.Col + 1; c < cMax.Col; c++)
        {
            if (CheckRowX(cMin.Col, c, cMin.Row)
            && CheckColY(cMin.Row, cMax.Row, c)
            && CheckRowX(c, cMax.Col, cMax.Row))
            {
                Debug.Log($"Grid Log: Hàng Cần Tìm {c}");
                return c;
            }
        }

        return -1;
    }

    public int CheckRectY(Cell cell1, Cell cell2)
    {
        Cell cMin = cell1;
        Cell cMax = cell2;

        if(cMin.Row > cMax.Row)
        {
            cMin = cell2;
            cMax = cell1;
        }

        for(int r = cMin.Row + 1; r < cMax.Row; r++)
        {
            if(CheckColY(cMin.Row, r, cMax.Row)
            && CheckRowX(cMin.Col, cMax.Col, r)
            && CheckColY(r, cMax.Row, cMax.Col))
            {
                Debug.Log($"Row cần tìm {r}");
                return r;
            }
        }
        return -1;
    }

    //Tìm kiếm mở rộng theo hình chữ nhật ngang
    public void CheckMoreLineX(Cell cell1, Cell cell2, int type)
    {
        Cell cellMinCol = cell1; //ô có chỉ số cột nhỏ nhất
        Cell cellMaxCol = cell2; // ô có chỉ số cột lớn hơn

        if(cellMinCol.Col > cellMaxCol.Col)
        {
            cellMinCol = cell2;
            cellMaxCol = cell1;
        }

        int y = cellMaxCol.Col; //Tọa độ cột lớn nhất
        int row = cellMinCol.Row; //Tọa độ hàng

        if(type == -1)
        {
            y = cellMinCol.Col; // Ô có chỉ số cột nhỏ hơn
            row = cellMaxCol.Row; //Hàng có pMax
        }

        //Check more
    }
}
