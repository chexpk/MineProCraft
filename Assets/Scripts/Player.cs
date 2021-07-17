using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SoundEvent : UnityEvent<string>
{
}

public class Player : MonoBehaviour
{
    public SoundEvent soundEvent = new SoundEvent();

    [SerializeField] Camera camera;
    [SerializeField] private Inventory inventory;
    [SerializeField] GameObject particleHit;
    [SerializeField] GameObject shootPoint;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        CreateMode();
    }

    void CreateMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // CreateVoxel();
            Interact();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DeleteVoxel();
        }
    }

    void CreateVoxel()
    {
        if (RaycastMousePosition(out var hit))
        {
            CreateVoxelOnHit(hit);
        }
    }

    void Interact()
    {
        if (inventory.IsCurrentInventoryItemExist())
        {
            if (inventory.currentInventoryItem.item.itemType == "tool")
            {
                TryShoot();
            }

            if (inventory.currentInventoryItem.item.itemType == "block")
            {
                CreateVoxel();
            }
        }
    }

    void TryShoot()
    {
        var arrowItem = inventory.GetArrowFromInventory();
        if (arrowItem == null) return;

        var arrowPref = arrowItem.item.prefab;
        CreateArrow(arrowPref);
        DecreaseCountThisItem(arrowItem);
        soundEvent.Invoke("shoot");
    }

    //TODO вероятно вынести в отдельный класс
    void CreateArrow(GameObject arrowPref)
    {
        var arrow = Instantiate(arrowPref, shootPoint.transform.position, Quaternion.identity);
        var rigidbodyArrow = arrow.GetComponent<Rigidbody>();
        var forcePower = 20f;
        rigidbodyArrow.velocity = camera.transform.forward * forcePower;
        arrow.transform.rotation = Quaternion.LookRotation(rigidbodyArrow.velocity);
    }

    //TODO: это не удаление, это удар - изменить в соответствии со смыслом
    void DeleteVoxel()
    {
        if (RaycastMousePosition(out var hit))
        {
            //TODO: обернуть и откорректировать
            Instantiate(particleHit, hit.point, Quaternion.identity);
            DeleteVoxelOnHit(hit);
        }
    }

    bool RaycastMousePosition(out RaycastHit hit)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }

    void CreateVoxelOnHit(RaycastHit hit)
    {
        GameObject hitedGO = hit.collider.gameObject;
        PlacePoint placePoint = hitedGO.GetComponent<PlacePoint>();

        if (placePoint == null) return;

        var pref = GetCurrentPrefab();
        GameObject voxelGO = Instantiate(pref, placePoint.GetPlacePosition(), Quaternion.identity);
        Voxel voxel = voxelGO.GetComponent<Voxel>();
        voxel.SetItem(inventory.currentInventoryItem.item);

        DecreaseCountItem();
    }

    // TODO rename InteractVoxelOnHit or HitVoxelOnHit ?
    void DeleteVoxelOnHit(RaycastHit hit)
    {
        GameObject parentHittedGO = hit.transform.parent.gameObject;
        Voxel voxel = parentHittedGO.GetComponent<Voxel>();
        if (voxel == null) return;
        // тут проверка "здоровья" + ошибка при попытке удалить что-то кроме вокселя
        voxel.DecreaseDurability();
        soundEvent.Invoke("hit");
    }

    void DecreaseCountItem()
    {
        inventory.DecreaseCountItem();
    }

    void DecreaseCountThisItem(InventoryItem inventoryItem)
    {
        inventoryItem.Decrease();
    }

    GameObject GetCurrentPrefab()
    {
        return inventory.GetCurrentItemPrefab();
    }
}
