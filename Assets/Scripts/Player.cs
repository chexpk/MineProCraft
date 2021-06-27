using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
    {
    public Camera camera;
    public GameObject voxelPref;
    [SerializeField]
    private Inventory inventory;
    PlacePoint oldHitedPP = null;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        RaycastSelectPlacePoint();
        CreateMode();
    }

    void CreateMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateVoxel();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DeleteVoxel();
        }
    }

    void CreateVoxel()
    {
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
        {
            CreateVoxelOnHit(hit);
        }
    }

    void DeleteVoxel()
    {
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
        {
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

    void DeleteVoxelOnHit(RaycastHit hit) // rename InteractVoxelOnHit or HitVoxelOnHit ?
    {
        GameObject parentHittedGO = hit.transform.parent.gameObject;
        Voxel voxel = parentHittedGO.GetComponent<Voxel>();
        if (voxel == null) return;
        // тут проверка "здоровья" + ошибка при попытке удалить что-то кроме вокселя
        voxel.DecreaseHealth();

        // voxel.DeleteVoxel();
    }

    // void DecreaseVoxelDurability(Voxel voxel)
    // {
    //     voxel.DecreaseHealth();
    // }

    void RaycastSelectPlacePoint ()
    {
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
        {
            SelectPlacePointOnHit(hit);
        }
        else
        {
            UnSelectPlacePoint(oldHitedPP);
            oldHitedPP = null;
        }
    }

    void SelectPlacePointOnHit(RaycastHit hit)
    {
        var placePoint = hit.collider.gameObject.GetComponent<PlacePoint>();

        if (placePoint == oldHitedPP) return;
        if (placePoint == null)
        {
            UnSelectPlacePoint(oldHitedPP);
            oldHitedPP = null;
            return;
        }

        UnSelectPlacePoint(oldHitedPP);
        placePoint.SelectPoint();
        oldHitedPP = placePoint;
    }

    void UnSelectPlacePoint(PlacePoint placePoint)
    {
        if (placePoint == null) return;

        placePoint.UnSelectPoint();
    }

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
        if (block.IsExist())
        {
            var item = block.GetItem();
            block.DeleteMiniBlock();
            inventory.CollectItem(item);
        }
    }

    void DecreaseCountItem()
    {
        inventory.DecreaseCountItem();
    }

    GameObject GetCurrentPrefab()
    {
        return inventory.GetCurrentItemPrefab();
    }
}
