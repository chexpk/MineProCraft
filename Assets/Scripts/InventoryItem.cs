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
    }

    public int GetCount()
    {
        return count;
    }


}
