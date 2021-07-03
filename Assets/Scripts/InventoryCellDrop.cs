using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryCell inventoryCell;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        // Debug.Log(eventData.pointerDrag);
        // var rectTransform = GetComponent<RectTransform>();
        // eventData.pointerDrag.transform.SetParent(transform);
        // var otherRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        // Debug.Log(otherRectTransform.anchoredPosition);
        // Debug.Log(rectTransform.anchoredPosition);
        // otherRectTransform.anchoredPosition = rectTransform.anchoredPosition;

        var draggable =  eventData.pointerDrag.GetComponent<InventoryCellDrag>();
        var draggableInventoryItem = draggable.GetInventoryItem();
        Debug.Log(draggableInventoryItem);
        Debug.Log(inventoryCell.GetInventoryItem());

        MoveTo(draggableInventoryItem, inventoryCell.GetInventoryItem());
    }

    void MoveTo(InventoryItem from, InventoryItem to)
    {
        to.AddInventoryItem(from);
    }
}
