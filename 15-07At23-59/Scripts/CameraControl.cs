using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] float cameraSpeed;

    void Update()
    {
        WasdMovement();
        MouseDrag();
    }

    private void MouseDrag()
    {
        Vector3 lastPosition = transform.position;
    
    }

    private void WasdMovement()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * cameraSpeed;
        float zAxisValue = Input.GetAxis("Vertical") * cameraSpeed;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + zAxisValue, transform.position.z);
    }
}
