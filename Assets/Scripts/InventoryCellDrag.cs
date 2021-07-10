using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    private Vector2 basePosition;
    [SerializeField] private InventoryCell inventoryCell;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        basePosition = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = basePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public InventoryItem GetInventoryItem()
    {
        return inventoryCell.GetInventoryItem();
    }
}
