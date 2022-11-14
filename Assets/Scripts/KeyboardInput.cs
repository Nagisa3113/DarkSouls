﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IUserInput
{
    //Variable
    [Header("===== Key settings =====")] public string keyUp;
    public string keyDown;
    public string keyLeft;
    public string keyRight;

    public string keyA;
    public string keyB;
    public string keyC;
    public string keyD;

    public string keyJLeft;
    public string keyJRight;
    public string keyJUp;
    public string keyJDown;

    [Header("===== Mouse settings =====")] public bool mouseEnable = false;
    public float mouseSensitivityX = 1.0f;
    public float mouseSensitivityY = 1.0f;


    // Update is called once per frame
    void Update()
    {
        if (mouseEnable == true)
        {
            JUp = Input.GetAxis("Mouse Y") * 3.0f * mouseSensitivityY;
            JRight = Input.GetAxis("Mouse X") * 2.5f * mouseSensitivityX;
        }
        else
        {
            JUp = (Input.GetKey(keyJUp) ? 1.0f : 0) - (Input.GetKey(keyJDown) ? 1.0f : 0);
            JRight = (Input.GetKey(keyJRight) ? 1.0f : 0) - (Input.GetKey(keyJLeft) ? 1.0f : 0);
        }

        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);

        if (inputEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempDAxis = SquareToCircle(new Vector2(Dright, Dup));
        float Dright2 = tempDAxis.x;
        float Dup2 = tempDAxis.y;

        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;

        run = Input.GetKey(keyA);
        defense = Input.GetKey(keyD);

        bool newJump = Input.GetKey(keyB);
        jump = newJump;
        if (newJump != lastJump && newJump == true)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        lastJump = newJump;

        bool newAttack = Input.GetKey(keyC);
        // todo
        if (newAttack != lastAttack && newAttack == true)
        {
            rb = true;
        }
        else
        {
            rb = false;
        }

        lastAttack = newAttack;
    }
}