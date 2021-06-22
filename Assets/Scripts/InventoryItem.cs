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
    [SerializeField] private List<int> indexCellsList;


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

    public void SetIndexCell(int index)
    {
        // indexCell = index;
        indexCellsList.Add(index);
    }

    public List<int> GetIndexCell()
    {
        return indexCellsList;
    }

    public void RemoveFromIndexCellsList(int index)
    {
        foreach (var indexCell in indexCellsList)
        {
            if (indexCell == index)
            {
                indexCellsList.Remove(index);
            }
        }
    }

    public void ClearInventoryItem()
    {
        item = null;
        isExist = false;
        indexCellsList.Clear();
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
