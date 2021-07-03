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

    public void Render()
    {
        cell.Render(this);
    }

    public void Increase()
    {
        count++;
        SetExist();
        Render();
    }

    public void Decrease()
    {
        count--;
        SetExist();
        if (!isExist)
        {
            ClearInventoryItem();
        }
        Render();
    }

    public void SetCell(InventoryCell cell)
    {
        this.cell = cell;
        Render();
    }

    public void SetInventoryItemInCell()
    {
        Render();
    }

    void ClearInventoryItem()
    {
        item = null;
        isExist = false;
        count = 0;
    }

    public void RenderCountItem()
    {
        Render();
    }

    public void UnselectCell()
    {
        cell.DeactivateCellFrame();
    }

    public void Select()
    {
        cell.ActivateCellFrame();
    }

    public bool AddInventoryItem(InventoryItem inventoryItem)
    {
        if (!inventoryItem.isExist) return false;
        if (item != inventoryItem.item && isExist) return false;

        item = inventoryItem.item;
        count += inventoryItem.count;
        isExist = true;
        Render();
        inventoryItem.ClearInventoryItem();
        inventoryItem.Render();
        
        return true;
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
