using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Craft : MonoBehaviour
{
    [SerializeField] InventoryItem[] inventoryItems = new InventoryItem[9];
    [SerializeField] Recipe[] recipies;
    [SerializeField] InventoryItem output;

    void Start()
    {
        ListenInventoryItemChanged();
        Draw();
        TryCook();
        output.changedEvent.AddListener(OnOutputChanged);
    }

    private void OnOutputChanged(string eventType)
    {
        if (eventType == "movefrom")
        {
            var recipe = CookableRecipe();
            recipe.Cook(inventoryItems);
        }
    }

    void ListenInventoryItemChanged()
    {
        foreach (var inventoryItem in inventoryItems)
        {
            inventoryItem.changedEvent.AddListener(OnInventoryItemChanged);
        }
    }

    void OnInventoryItemChanged(string eventType)
    {
        Debug.Log("создаю");
        TryCook();
    }

    void TryCook()
    {
        output.ClearInventoryItem();
        var recipe = CookableRecipe();
        if (recipe != null)
        {
            output.item = recipe.output;
            output.Increase();
        }
    }

    void Draw()
    {
        foreach (var inventoryItem in inventoryItems)
        {
            inventoryItem.Render();
        }
    }

    Recipe CookableRecipe()
    {
        foreach (var recipe in recipies)
        {
            if (recipe.IsCookable(inventoryItems))
            {
                return recipe;
            }
        }
        return null;
    }
}
