using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] GameObject _main;
    [SerializeField] SpriteRenderer _cell;
    [SerializeField] SpriteRenderer _icon;
    [SerializeField] Sprite _unSelect, _select;
    public int ID;

    public int Row { get; }
    public int Col { get; }

    public event Action<Cell> OnCellClickEvent;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        UnSelect();
    }

    private void OnMouseDown()
    {
        OnCellClickEvent?.Invoke(this);
    }

    public void OnSelected()
    {
        UpdateUICell(_select);
    }

    public void UnSelect()
    {
        UpdateUICell(_unSelect);
    }

    void UpdateUICell(Sprite newSprite)
    {
        _cell.sprite = newSprite;
    }

    public void UpdateIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }

    public void UpdateSortLayer()
    {
        float sum = transform.position.x - transform.position.y;
        int sortOrder = Mathf.RoundToInt(sum * 10);
        _cell.sortingOrder = sortOrder;
        _icon.sortingOrder = sortOrder + 1;
    }

    public void SetPos(Vector2 newPos) => transform.position = newPos;

    public void ShowUI(bool isShow)
    {
        _main.SetActive(isShow);
    }

    
}

