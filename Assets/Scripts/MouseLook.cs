using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    void Update()
    {
        // вращается все прикрепленное к Player
        float deltaX = Input.GetAxis("Mouse Y") * sensitivity;
        _rotationX -= deltaX;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float deltaY = Input.GetAxis("Mouse X") * sensitivity;
        float rotationY = transform.localEulerAngles.y + deltaY;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}

