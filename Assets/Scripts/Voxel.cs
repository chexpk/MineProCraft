using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public void SetMaterial (Material material)
    {
        GameObject cubeGO = transform.Find("Cube").gameObject;
        cubeGO.GetComponent<Renderer>().material = material;
    }

    public void DeleteVoxel ()
    {
        Destroy(gameObject);
    }
}
