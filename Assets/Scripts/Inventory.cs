using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int maxInventoryItems = 9;
    public InventoryItem[] items = new InventoryItem[maxInventoryItems];
    public InventoryCell[] cells;
    public InventoryItem currentInventoryItem;

    private void Start()
    {
        SetInventoryItemsToCells();
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

    public void CollectItem(Item item)
    {
        int index = 0;
        foreach (var currentItem in items)
        {
            if (currentItem.item == null) //адекватная проверка?
            {
                index++;
                continue;
            }
            if (currentItem.item.name == item.name)
            {
                currentItem.Increase();
                return;
            }
            index++;
        }

        if (index >= maxInventoryItems)
        {
            foreach (var inventoryItem in items)
            {
                //в перспективе добавить проверку на заполненность
                if (!inventoryItem.isExist)
                {
                    inventoryItem.item = item; //обернуть в метод?
                    inventoryItem.Increase();
                    inventoryItem.SetInventoryItemInCell();
                    return;
                }
            }
        }
    }
    public void DecreaseCountItem()
    {
        currentInventoryItem.Decrease();
        if (currentInventoryItem.isExist)
        {
            currentInventoryItem.RenderCountItem();
        }
        else
        {
            currentInventoryItem.ClearInventoryItem();
            currentInventoryItem.Select();
        }
    }

    public GameObject GetCurrentItemPrefab()
    {
        return currentInventoryItem.item.prefab;
    }
}
