using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    [SerializeField] InventoryItem[] inventoryItems = new InventoryItem[9];
    // Start is called before the first frame update
    void Start()
    {
        Draw();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Draw()
    {
        foreach (var inventoryItem in inventoryItems)
        {
            inventoryItem.Render();

        }
    }
}
