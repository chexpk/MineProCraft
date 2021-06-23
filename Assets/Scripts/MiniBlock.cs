using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBlock : MonoBehaviour
{
    public Item item;

    public bool isExist = true;
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
        isExist = false;
        Destroy(gameObject);
    }

    public Item GetItem()
    {
        return item;
    }

    public bool IsExist()
    {
        return isExist;
    }
}
