using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int maxInventoryItems = 9;
    public InventoryItem[] items = new InventoryItem[maxInventoryItems];
    public InventoryCell[] cells;
    public InventoryItem currentInventoryItem;


    public bool CollectItem(Item item)
    {
        var inventoryItem = FindInventoryItem(item);
        if (inventoryItem != null)
        {
            //в перспективе добавить проверку на заполненность
            inventoryItem.Increase();
            return true;
        }

        var emptyInventoryItem = FindFirstEmptyInventoryItem();
        if (emptyInventoryItem != null)
        {
            emptyInventoryItem.item = item;
            emptyInventoryItem.Increase();
            return true;
        }
        return false;
    }

    public void DecreaseCountItem()
    {
        currentInventoryItem.Decrease();
    }

    public GameObject GetCurrentItemPrefab()
    {
        return currentInventoryItem.item.prefab;
    }

    public bool IsCurrentInventoryItemExist()
    {
        return currentInventoryItem.isExist;
    }

    private void Start()
    {
        SetInventoryItemsToCells();
        SelectItem(0);
    }

    private void SetInventoryItemsToCells()
    {
        int index = 0;
        foreach (var cell in cells)
        {
            var inventoryItem = items[index];
            inventoryItem.SetCell(cell);
            index++;
        }
    }

    private void Update()
    {
        DetectPressed();
    }

    void DetectPressed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectItem(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectItem(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectItem(8);
        }
    }

    void SelectItem(int index)
    {
        currentInventoryItem = items[index];
        UnSelectAllInventory();
        currentInventoryItem.Select();
    }

    private void UnSelectAllInventory()
    {
        int index = 0;
        foreach (var item in items)
        {
            item.UnselectCell();
            index++;
        }
    }

    InventoryItem FindInventoryItem(Item item)
    {
        foreach (var currentItem in items)
        {
            if (currentItem.isExist && currentItem.item == item)
            {
                return currentItem;
            }
        }
        return null;
    }

    InventoryItem FindFirstEmptyInventoryItem()
    {
        foreach (var inventoryItem in items)
        {
            if (!inventoryItem.isExist)
            {
                return inventoryItem;
            }
        }
        return null;
    }

    public bool IsAmmunitionExist()
    {
        return true;
    }
}
