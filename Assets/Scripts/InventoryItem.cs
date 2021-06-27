using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    public bool isExist = false;
    public int count = 0;
    public InventoryCell cell;

    public void Increase()
    {
        count++;
        SetExist();
        RenderCountItem();
    }

    public void Decrease()
    {
        count--;
        SetExist();
    }

    public void SetCell(InventoryCell cell)
    {
        this.cell = cell;
        SetInventoryItemInCell();
        RenderCountItem();
    }

    public void SetInventoryItemInCell()
    {
        cell.SetInventoryItem(this);
    }

    public void ClearInventoryItem()
    {
        item = null;
        isExist = false;
        count = 0;
        cell.ClearCell();
    }

    public void RenderCountItem()
    {
        cell.RenderCountItem(count);
    }

    public void UnselectCell()
    {
        cell.DeactivateCellFrame();
    }

    public void Select()
    {
        cell.ActivateCellFrame();
    }

    void SetExist()
    {
        if (count > 0)
        {
            isExist = true;
        }
        else
        {
            isExist = false;
        }
    }
}
