using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
    {
    public Camera camera;
    public GameObject voxelPref;
    [SerializeField] private Inventory inventory;
    PlacePoint oldHitedPP = null;

    [SerializeField] GameObject particleHit;
    [SerializeField] GameObject handPoint;

    //TODO: удалить после настройки выстрела - заменить на метод в inventory
    public GameObject ammoPre;


    void Start()
    {
        // Screen.lockCursor = true;
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
        //  является тул
        // if (IsTool())
        //{
        //    TryShoot();
        //}
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
        {
            CreateVoxelOnHit(hit);
        }
    }

    void Interact()
    {
        if (inventory.IsCurrentInventoryItemExist())
        {
            if (inventory.currentInventoryItem.item.itemTyp == "tool")
            {
                TryShoot();
            }

            if (inventory.currentInventoryItem.item.itemTyp == "block")
            {
                RaycastHit hit;

                if (RaycastMousePosition(out hit))
                {
                    CreateVoxelOnHit(hit);
                }
            }
        }
    }

    void TryShoot()
    {
        //существует,в инвентаре есть боезапас
        // ЗапускСтрелы()
        //
        if (inventory.IsAmmunitionExist())
        {
            //var ammPref = inventory.GetCurrentAmmoPref();
            var arrow = Instantiate(ammoPre, handPoint.transform.position, Quaternion.identity);
            // arrow.transform.rotation = handPoint.transform.rotation;
            var rigidbodyArrow = arrow.GetComponent<Rigidbody>();
            var forcePower = 9f;
            // rigidbodyArrow.AddForce(arrow.transform.forward * forcePower, ForceMode.Impulse);
            rigidbodyArrow.velocity = camera.transform.forward * forcePower;
            arrow.transform.rotation = Quaternion.LookRotation(rigidbodyArrow.velocity);
        }
    }

    //TODO: это не удаление, это удар - изменить в соответствии со смыслом
    void DeleteVoxel()
    {
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
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

    void DeleteVoxelOnHit(RaycastHit hit) // TODO rename InteractVoxelOnHit or HitVoxelOnHit ?
    {
        GameObject parentHittedGO = hit.transform.parent.gameObject;
        Voxel voxel = parentHittedGO.GetComponent<Voxel>();
        if (voxel == null) return;
        // тут проверка "здоровья" + ошибка при попытке удалить что-то кроме вокселя
        voxel.DecreaseDurability();
    }

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
        var item = block.GetItem();
        if (block.IsExist() && inventory.CollectItem(item))
        {
            block.DeleteMiniBlock();
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
