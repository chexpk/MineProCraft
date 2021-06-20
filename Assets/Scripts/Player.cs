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
    // public Palette palette;

    PlacePoint oldHitedPP = null;

    enum Mode
    {
        CreateMode = 0,
        PaintMode = 1
    }

    Mode _currentMode = Mode.CreateMode;

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        RaycastSelectPlacePoint();
        RaycastTool();
    }

    void RaycastTool()
    {
        if (_currentMode == Mode.CreateMode)
        {
            CreateModeRaycast();
            return;
        }

        if (_currentMode == Mode.PaintMode)
        {
            PaintModeRaycast();
        }
    }

    void CreateModeRaycast()
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

    void PaintModeRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PaintVoxel();
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

    void PaintVoxel()
    {
        RaycastHit hit;

        if (RaycastMousePosition(out hit))
        {
            PaintVoxelOnHit(hit);
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

        // TODO: оформить вытаскивание "матрешки"
        var pref = inventory.currentInventoryItem.item.prefab;
        GameObject voxelGO = Instantiate(pref, placePoint.GetPlacePosition(), Quaternion.identity);
        Voxel voxel = voxelGO.GetComponent<Voxel>();
        voxel.SetItem(inventory.currentInventoryItem.item);
        // Material material = palette.currentMaterial;
        // voxel.SetMaterial(material);
    }

    void DeleteVoxelOnHit(RaycastHit hit)
    {
        GameObject parentHittedGO = hit.transform.parent.gameObject;
        Voxel voxel = parentHittedGO.GetComponent<Voxel>();

        if (voxel == null) return;

        voxel.DeleteVoxel();

    }

    void PaintVoxelOnHit(RaycastHit hit)
    {
        GameObject parentHittedGO = hit.transform.parent.gameObject;
        Voxel voxel = parentHittedGO.GetComponent<Voxel>();

        if (voxel == null) return;

        // Material material = palette.currentMaterial;
        // voxel.SetMaterial(material);
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

    public void SetCreateMode ()
    {
        _currentMode = Mode.CreateMode;
    }

    public void SetPaintMode ()
    {
        _currentMode = Mode.PaintMode;
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
        block.DeleteMiniBlock();
        inventory.CollectItem(item);
    }
}
