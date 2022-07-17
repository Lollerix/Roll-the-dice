using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] float cameraWasdSpeed;
    [SerializeField] float dragSpeed;
    Vector2 mouseClickPos;
    Vector2 mouseCurrentPos;
    bool panning = false;


    [SerializeField] float widthBorderSpeed;
    [SerializeField] float heightBorderSpeed;
    float leftBorder = Screen.width * 0.05f;
    float rightBorder = Screen.width * 0.95f;
    float topBorder = Screen.height * 0.95f;
    float bottomBorder = Screen.height * 0.05f;

    Camera cam;
    public float maxZoom = 4;
    public float minZoom = 0.1f;
    [SerializeField] float zoomSpeed;
    public float zoomSpeed2 = 1;
    float targetZoom;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        WasdMovement();
        MmbMovement();
        ZoomMovement();

    }

    private void ZoomMovement()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            targetZoom += Input.mouseScrollDelta.y * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, maxZoom, minZoom);
            float newSize = Mathf.MoveTowards(cam.orthographicSize, targetZoom, zoomSpeed2 * Time.deltaTime);
            cam.orthographicSize = newSize;
        }
    }

    private void MmbMovement()
    {
        // When MMB clicked get mouse click position and set panning to true
        if (Input.GetKeyDown(KeyCode.Mouse2) && !panning)
        {
            mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            panning = true;
        }
        // If MMB is already clicked, move the camera following the mouse position update
        if (panning)
        {
            mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distance = mouseCurrentPos - mouseClickPos;
            transform.position += new Vector3(-distance.x, -distance.y, 0);
        }

        // If MMB is released, stop moving the camera
        if (Input.GetKeyUp(KeyCode.Mouse2))
            panning = false;
    }


    //Si occupa del movimento con wasd
    private void WasdMovement()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * cameraWasdSpeed;
        float zAxisValue = Input.GetAxis("Vertical") * cameraWasdSpeed;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + zAxisValue, transform.position.z);
    }
}
