using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("MiniBlock"))
        {
            CollectMiniBlock(hit.gameObject);
        }
    }

    void CollectMiniBlock(GameObject miniBlock)
    {
        MiniBlock block = miniBlock.GetComponent<MiniBlock>();
        var item = block.GetItem();
        if (block.IsExist() && inventory.CollectItem(item))
        {
            block.DeleteMiniBlock();
        }
    }
}
