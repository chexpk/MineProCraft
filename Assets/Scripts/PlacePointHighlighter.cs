using UnityEngine;

public class PlacePointHighlighter : MonoBehaviour
{
    [SerializeField] Camera camera;

    PlacePoint oldHitedPP = null;

    void Update()
    {
        RaycastSelectPlacePoint();
    }

    void RaycastSelectPlacePoint ()
    {
        if (RaycastMousePosition(out var hit))
        {
            SelectPlacePointOnHit(hit);
        }
        else
        {
            UnSelectPlacePoint(oldHitedPP);
            oldHitedPP = null;
        }
    }

    bool RaycastMousePosition(out RaycastHit hit)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
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
}
