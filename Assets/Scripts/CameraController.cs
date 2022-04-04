using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerInput pi;
    public float horizontalSpeed = 80.0f;
    public float verticalSpeed = 80.0f;
    public float cameraDampValue = 0.05f;

    private GameObject playerHandle;
    private GameObject camerHandle;

    private float tempEulerX;
    private GameObject model;
    private GameObject camera;

    private Vector3 cameraDampVelocity;

    private void Awake()
    {
        camerHandle = transform.parent.gameObject;
        playerHandle = camerHandle.transform.parent.gameObject;
        tempEulerX = 20;
        model = playerHandle.GetComponent<ActorController>().model;
        camera = Camera.main.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempModelEuler = model.transform.eulerAngles;

        playerHandle.transform.Rotate(Vector3.up, pi.JRight * horizontalSpeed * Time.deltaTime);
        // camerHandle.transform.Rotate(Vector3.right, pi.JUp * -horizontalSpeed * Time.deltaTime,
        //     Space.World);

        tempEulerX -= pi.JUp * verticalSpeed * Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -30, 30);
        camerHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
        
        model.transform.eulerAngles = tempModelEuler;
        camera.transform.position =
            Vector3.SmoothDamp(camera.transform.position, transform.position, ref cameraDampVelocity, cameraDampValue);
        // camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position, 0.2f);
        camera.transform.eulerAngles = transform.eulerAngles;
    }
}