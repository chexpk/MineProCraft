using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    public bool isExist = false;
    public int count = 10;

    public void Increase()
    {
        count++;
        SetExist(count);
    }

    public int GetCount()
    {
        return count;
    }

    public void Decriase()
    {
        count--;
        SetExist(count);
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
