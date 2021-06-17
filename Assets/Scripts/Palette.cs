using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    public Material currentMaterial;

    public Material red;
    public Material blue;

    public void PickRedColor ()
    {
        currentMaterial = red;
    }

    public void PickBlueColor()
    {
        currentMaterial = blue;
    }
}
