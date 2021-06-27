using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    [SerializeField] InventoryItem[] inventoryItems = new InventoryItem[9];
    [SerializeField] Recipe[] recipies;
    [SerializeField] InventoryItem output;


    // Start is called before the first frame update
    void Start()
    {
        Draw();
        var item = TryCook();
        if (item != null)
        {
            output.item = TryCook();
            output.Increase();
        }
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

    Item TryCook()
    {
        foreach (var recipe in recipies)
        {
            if (recipe.IsCookable(inventoryItems))
            {
                return recipe.output;
            }
        }
        return null;
    }
}
