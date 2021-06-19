using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBlock : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void DeleteMiniBlock ()
    {
        Destroy(gameObject);

    }

    public Item GetItem()
    {
        return item;
    }
}
