using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] items = new InventoryItem[9];
    public InventoryCell[] cells;
    public InventoryItem currentInventoryItem;


    private void Start()
    {
        int index = 0;
        foreach (var cell in cells)
        {
            cell.SetInventoryItem(items[index]);
            RenderCountItem(items[index], cell);
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
        UnSelectAllCells();
        cells[index].Select();
    }

    private void UnSelectAllCells()
    {
        int indexCell = 0;
        foreach (var cell in cells)
        {
            cell.DeactivateCellFrame();
            indexCell++;
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
                RenderCountItem(currentItem, cells[index]);
            }
            index++;
        }
    }

    void RenderCountItem(InventoryItem inventoryItem, InventoryCell inventoryCell)
    {
        var countInt = inventoryItem.GetCount();
        inventoryCell.RenderCountItem(countInt);
    }
}
