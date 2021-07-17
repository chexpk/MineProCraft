using System;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject handPoint;
    [SerializeField] private Inventory inventory;

    GameObject currentHandItem;

    private void Start()
    {
        inventory.currentInventoryItemChanged.AddListener(HandPlaceRender);
    }

    void HandPlaceRender()
    {
        var newItemInHand = GetHandPref();
        if (newItemInHand != null)
        {
            Destroy(currentHandItem);
            currentHandItem = Instantiate(newItemInHand, handPoint.transform);
        }
        else
        {
            Destroy(currentHandItem);
        }
    }

    GameObject GetHandPref()
    {
        return inventory.GetCurrentItemHandPrefab();
    }
}
