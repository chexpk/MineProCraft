using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedFrame;
    [SerializeField] private Text countItemInCell;

    public void Render(InventoryItem inventoryItem)
    {
        if (inventoryItem.isExist)
        {
            SetInventoryItem(inventoryItem);
            RenderCountItem(inventoryItem.count);
        }
        else
        {
            ClearCell();
        }
    }

    public void ActivateCellFrame()
    {
        selectedFrame.SetActive(true);
    }

    public void DeactivateCellFrame()
    {
        selectedFrame.SetActive(false);
    }

    void RenderItemPreview(InventoryItem inventoryItem)
    {
        var sprite = inventoryItem.item.inventoryPreview;
        image.sprite = sprite;
    }

    void RenderCountItem(int countItem)
    {
        countItemInCell.text = countItem.ToString();
    }

    void SetInventoryItem(InventoryItem inventoryItem)
    {
        if (inventoryItem.isExist)
        {
            RenderItemPreview(inventoryItem);
        }
        // DeactivateCellFrame();
    }

    void ClearCell()
    {
        image.sprite = null;
        countItemInCell.text = " ";
    }
}

