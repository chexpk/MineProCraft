using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedFrame;
    [SerializeField] private Text countItemInCell;

    public void SetInventoryItem(InventoryItem inventoryItem)
    {
        if (inventoryItem.isExist)
        {
            RenderItemPreview(inventoryItem);
        }
        DeactivateCellFrame();
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
        button.image.sprite = null;
        countItemInCell.text = " ";
    }
    public void ActivateCellFrame()
    {
        selectedFrame.SetActive(true);
    }
}

