using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePoint : MonoBehaviour
{
    public Material selectedMaterial;
    public Material unSelectedMaterial;

    public Vector3 GetPlacePosition ()
    {
        return transform.position - 0.5f * transform.forward;
    }

    public void SelectPoint ()
    {
        transform.GetComponent<Renderer>().material = selectedMaterial;
    }

    public void UnSelectPoint ()
    {
        transform.GetComponent<Renderer>().material = unSelectedMaterial;
    }
}
