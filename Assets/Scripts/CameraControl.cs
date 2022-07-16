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

    void Start()
    {
    }

    void Update()
    {
        WasdMovement();

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        BorderScreenMovement(mousePosition);

        // When LMB clicked get mouse click position and set panning to true
        if (Input.GetKeyDown(KeyCode.Mouse0) && !panning)
        {
            mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            panning = true;
        }
        // If LMB is already clicked, move the camera following the mouse position update
        if (panning)
        {
            mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distance = mouseCurrentPos - mouseClickPos;
            transform.position += new Vector3(-distance.x, -distance.y, 0);
        }

        // If LMB is released, stop moving the camera
        if (Input.GetKeyUp(KeyCode.Mouse0))
            panning = false;

    }

    private void BorderScreenMovement(Vector2 mousePosition)
    {


        if (mousePosition.x < leftBorder)
        {
            transform.position = new Vector3(transform.position.x - widthBorderSpeed, transform.position.y, transform.position.z);
        }
        else if (mousePosition.x > rightBorder)
        {
            transform.position = new Vector3(transform.position.x + widthBorderSpeed, transform.position.y, transform.position.z);
        }

        if (mousePosition.y < bottomBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - heightBorderSpeed, transform.position.z);
        }
        else if (mousePosition.y > topBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + heightBorderSpeed, transform.position.z);
        }

    }

    //Si occupa del movimento con wasd
    private void WasdMovement()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * cameraWasdSpeed;
        float zAxisValue = Input.GetAxis("Vertical") * cameraWasdSpeed;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + zAxisValue, transform.position.z);
    }
}
