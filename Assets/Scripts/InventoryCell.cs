using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public InventoryItem inventoryItemInCell;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedFrame;
    [SerializeField] private Text countItemInCell;
    [SerializeField] private bool isEmpty = true;

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
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
        countItemInCell.text = null;
        isEmpty = true;
        inventoryItemInCell = null;
    }
    private void ActivateCellFrame()
    {
        selectedFrame.SetActive(true);
    }
}

