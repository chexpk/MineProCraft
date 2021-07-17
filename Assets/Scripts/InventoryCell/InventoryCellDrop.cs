using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryCell inventoryCell;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        var draggable = eventData.pointerDrag.GetComponent<InventoryCellDrag>();
        var draggableInventoryItem = draggable.GetInventoryItem();
        MoveTo(draggableInventoryItem, inventoryCell.GetInventoryItem());
    }

    void MoveTo(InventoryItem from, InventoryItem to)
    {
        to.AddInventoryItem(from);
    }
}
