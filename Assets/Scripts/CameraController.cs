using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public IUserInput pi;
    public float horizontalSpeed = 80.0f;
    public float verticalSpeed = 80.0f;
    public float cameraDampValue = 0.05f;

    private GameObject playerHandle;
    private GameObject camerHandle;

    private float tempEulerX;
    private GameObject model;
    private GameObject _camera;

    private Vector3 cameraDampVelocity;

    private void Awake()
    {
        camerHandle = transform.parent.gameObject;
        playerHandle = camerHandle.transform.parent.gameObject;
        tempEulerX = 20;
        ActorController ac = playerHandle.GetComponent<ActorController>();
        model = ac.model;
        pi = ac.pi;
        _camera = Camera.main.gameObject;
    }

    void FixedUpdate()
    {
        Vector3 tempModelEuler = model.transform.eulerAngles;

        playerHandle.transform.Rotate(Vector3.up, pi.JRight * horizontalSpeed * Time.fixedDeltaTime);
        tempEulerX -= pi.JUp * verticalSpeed * Time.fixedDeltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -30, 30);
        camerHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

        model.transform.eulerAngles = tempModelEuler;
        _camera.transform.position =
            Vector3.SmoothDamp(_camera.transform.position, transform.position, ref cameraDampVelocity, cameraDampValue);
        // camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position, 0.2f);
        _camera.transform.eulerAngles = transform.eulerAngles;
    }
}