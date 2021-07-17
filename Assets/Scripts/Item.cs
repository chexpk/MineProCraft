using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string name;
    public GameObject prefab;
    public Sprite inventoryPreview;
    public GameObject miniPrefab;
    public string itemType;
}
