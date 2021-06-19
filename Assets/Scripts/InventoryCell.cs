using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Button button;

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        if (inventoryItem.isExist)
        {
            RenderItemPreview(inventoryItem);
        }
    }

    public void Select()
    {
        Debug.Log("ячейка выделилась");
    }
    

    void RenderItemPreview(InventoryItem inventoryItem)
    {
        var sprite = inventoryItem.item.inventoryPreview;
        button.image.sprite = sprite;
    }
}
