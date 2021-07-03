using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        Debug.Log(eventData.pointerDrag);
        var rectTransform = GetComponent<RectTransform>();
        eventData.pointerDrag.transform.SetParent(transform);
        var otherRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        Debug.Log(otherRectTransform.anchoredPosition);
        Debug.Log(rectTransform.anchoredPosition);
        otherRectTransform.anchoredPosition = rectTransform.anchoredPosition;
    }
}
