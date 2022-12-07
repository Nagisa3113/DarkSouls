﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUserInput : MonoBehaviour
{
    [Header("===== Output Signals =====")] public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    public float JUp;
    public float JRight;

    // 1. pressing signal
    public bool run;
    public bool defense;

    // 2. trigger once signal
    public bool jump;

    protected bool lastJump;

    // public bool attack;
    protected bool lastAttack;
    public bool roll;
    public bool lockon;
    public bool lb;
    public bool rb;
    public bool lt;
    public bool rt;

    // 3. double trigger
    [Header("===== Other settings =====")] public bool inputEnabled = true;
    protected float targetDup;
    protected float targetDright;
    protected float velocityDup;
    protected float velocityDright;


    //Mapping for Squaring the Circular Disc
    //arxiv.org/1509/1509.06344
    protected Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output = Vector2.zero;

        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);

        return output;
    }

    protected void UpdateDmagDvec(float Dup2, float Dright2)
    {
        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;
    }
}