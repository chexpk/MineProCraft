using System.Net;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public Item[] ingredients = new Item[9];
    public Item output;

    public bool IsCookable(InventoryItem[] inventoryItems)
    {
        int index = 0;
        foreach (var inventoryItem in inventoryItems)
        {
            if (ingredients[index] != inventoryItem.item)
            {
                return false;
            }
            index++;
        }
        return true;
    }

    public void Cook(InventoryItem[] inventoryItems)
    {
        int index = 0;
        foreach (var inventoryItem in inventoryItems)
        {
            if (ingredients[index] == inventoryItem.item && ingredients[index] != null)
            {
                inventoryItem.Decrease();
            }
            index++;
        }
    }
}
