using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public InventoryItem inventoryItemInCell;
    public bool isEmpty = true;
    public bool isFull = false;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedFrame;
    [SerializeField] private Text countItemInCell;
    [SerializeField] int indexInArray; //временно


    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        Debug.Log(inventoryItem.isExist);
        if (inventoryItem.isExist)
        {
            RenderItemPreview(inventoryItem);
            inventoryItemInCell = inventoryItem;
            isEmpty = false;
        }
        DeactivateCellFrame();
    }

    public void Select()
    {
        ActivateCellFrame();
    }

    public void DeactivateCellFrame()
    {
        selectedFrame.SetActive(false);
    }

    void RenderItemPreview(InventoryItem inventoryItem)
    {
        var sprite = inventoryItem.item.inventoryPreview;
        button.image.sprite = sprite;
    }

    public void RenderCountItem(int countItem)
    {
        countItemInCell.text = countItem.ToString();
    }

    public void ClearCell()
    {
        button.image.sprite = null; //так работает? если нет, то картинку на пустую ячейку найти
        countItemInCell.text = " ";
        isEmpty = true;
        inventoryItemInCell = null;
        isFull = false;
    }
    private void ActivateCellFrame()
    {
        selectedFrame.SetActive(true);
    }


    //ниже представлены методы временные - удалить после реализации иного метода хранения адреса ячеек в inventoryItems
    public void SetIndexInArray(int index)
    {
        indexInArray = index;
    }

    public int GetIndexInArray()
    {
        return indexInArray;
    }
}

