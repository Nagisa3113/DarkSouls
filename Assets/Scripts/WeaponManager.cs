using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public ActorManager am;
    private Collider weaponColL;
    private Collider weaponColR;
    public GameObject whL;
    public GameObject whR;


    private void Start()
    {
        whL = transform.DeepFind("weaponHandleL").gameObject;
        whR = transform.DeepFind("weaponHandleR").gameObject;
        weaponColL = whL.GetComponentInChildren<Collider>();
        weaponColR = whR.GetComponentInChildren<Collider>();
    }


    public void WeaponEnable()
    {
        if (am.ac.CheckStateTag("attackL"))
        {
            weaponColL.enabled = true;
        }
        else
        {
            weaponColR.enabled = true;
        }
    }

    public void WeaponDisable()
    {
        weaponColR.enabled = true;
        weaponColR.enabled = false;
    }
}