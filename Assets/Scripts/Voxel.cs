using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    [SerializeField] private Item item;
    private int durability = 3;
    //поле здоровья?

    // public void SetMaterial (Material material)
    // {
    //     GameObject cubeGO = transform.Find("Cube").gameObject;
    //     cubeGO.GetComponent<Renderer>().material = material;
    // }

    public void DeleteVoxel ()
    {
        Destroy(gameObject);

        var miniVoxel = Instantiate(item.miniPrefab, transform.position, Quaternion.identity);
        miniVoxel.GetComponent<MiniBlock>().SetItem(item);
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void DecreaseDurability()
    {
        durability--;
        if (durability <= 0)
        {
            DeleteVoxel();
        }
    }
}
