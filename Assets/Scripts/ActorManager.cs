using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public ActorController ac;
    public BattleManager bm;
    public WeaponManager wm;


    private void Awake()
    {
        ac = GetComponent<ActorController>();
        GameObject model = ac.model;
        GameObject sensor = transform.Find("sensor").gameObject;
        bm = sensor.GetComponent<BattleManager>();
        if (bm == null)
        {
            bm = sensor.AddComponent<BattleManager>();
        }

        bm.am = this;
        wm = model.GetComponent<WeaponManager>();
        if (wm == null)
        {
            wm = model.AddComponent<WeaponManager>();
        }

        wm.am = this;
    }
    
    public void DoDamage()
    {
        // ac.IssueTrigger("hit");
        ac.IssueTrigger("die");
    }
}