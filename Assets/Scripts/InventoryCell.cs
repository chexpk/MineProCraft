using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedFrame;
    [SerializeField] private Text countItemInCell;
    RectTransform rectTransform;
    private Vector2 basePosition;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

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

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
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
}

