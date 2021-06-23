using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    public bool isExist = false;
    public int count = 10;
    // [SerializeField] private int indexCell;
    public int indexOfCellAndInventoryItem;


    public void Increase()
    {
        count++;
        SetExist(count);
    }

    public int GetCount()
    {
        return count;
    }

    public void Decrease()
    {
        count--;
        SetExist(count);
    }

    public void SetIndex(int index)
    {
        indexOfCellAndInventoryItem = index;
    }

    public int GetIndex()
    {
        return indexOfCellAndInventoryItem;
    }

    public void ClearInventoryItem()
    {
        item = null;
        isExist = false;
        count = 0;
    }

    void SetExist(int count)
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
