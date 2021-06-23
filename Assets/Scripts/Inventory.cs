using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int maxInventoryItems = 9;
    public InventoryItem[] items = new InventoryItem[maxInventoryItems];
    public InventoryCell[] cells;
    public InventoryItem currentInventoryItem;
    public InventoryCell currentInventoryCell;


    private void Start()
    {
        int index = 0;
        foreach (var cell in cells)
        {
            cell.SetInventoryItem(items[index]);
            cell.SetIndexInArray(index); //удалить после реализации иного метода хранения адреса ячеек
            items[index].SetIndexCell(index);
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
        currentInventoryCell = cells[index];
        currentInventoryItem = items[index];
        UnSelectAllCells();
        currentInventoryCell.Select();
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

    //подготовка к WIP
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
                // обернуть в метод, в котором выбирать ячейку для прибавления countItems
                currentItem.Increase();
                var cell = SelectCellToIncreaseCountItem(currentItem);
                cell.inventoryItemInCell = currentItem;
                //в этом моменте я понял, что хранить адрес ячейки в виде индекса - плохо))) нужно придумать как
                // может быть прямо List  с ячейками?
                var indexCell = cell.GetIndexInArray();
                currentItem.SetIndexCell(indexCell);
                RenderCountItem(currentItem, cell);
                return;
            }
            index++;
        }

        if (index >= maxInventoryItems)
        {
            foreach (var inventoryItem in items)
            {
                if (!inventoryItem.isExist)
                {
                    // Debug.Log(inventoryItem.isExist);

                    inventoryItem.item = item;
                    inventoryItem.Increase();

                    // Debug.Log(inventoryItem.isExist);

                    var cell = SelectCellToIncreaseCountItem(inventoryItem);
                    cell.SetInventoryItem(inventoryItem);
                    // cell.inventoryItemInCell = inventoryItem;
                    var indexCell = cell.GetIndexInArray();
                    inventoryItem.SetIndexCell(indexCell);
                    RenderCountItem(inventoryItem, cell);
                    return;
                }
            }
        }
        //если index >= maxInventoryItems, то поиск свободной ячейки и присвоение ей inventoryItems.
        //или все будет по одному алгоритму? и нужен только метод для выбора ячейкив которой будет
        //увиличиваться число айтемов?
    }
    public void DecreaseCountItem()
    {
        currentInventoryItem.Decrease();
        //проверка на isExist, если да, то
        if (currentInventoryItem.isExist)
        {
            var countInt = currentInventoryItem.GetCount();
            currentInventoryCell.RenderCountItem(countInt);
        }
        else
        {
            //очистить привязку inventoryItem к ячейкам
            currentInventoryItem.ClearInventoryItem();
            //очистить привязку к inventoryItem, перерисовать пустую ячейку
            currentInventoryCell.ClearCell();
        }
    }

    void RenderCountItem(InventoryItem inventoryItem, InventoryCell inventoryCell)
    {
        var countInt = inventoryItem.GetCount();
        inventoryCell.RenderCountItem(countInt);
    }

    //TODO: переписать метод
    InventoryCell SelectCellToIncreaseCountItem(InventoryItem inventoryItem)
    {
        InventoryCell result = null; //как это правильно написать?
        List<int> indexes = inventoryItem.GetIndexCell();
        foreach (var index in indexes)
        {
            if (!cells[index].isFull)
            {
                // Debug.Log("есть не полные");
                return cells[index];
            }
        }
        foreach (var cell in cells)
        {
            if (cell.isEmpty)
            {
                // Debug.Log("есть пустые");
                result = cell;
                return result;
            }
        }
        Debug.Log("все ячейки заполнены");
        return result;
    }
}
