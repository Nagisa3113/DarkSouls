using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public ActorController ac;
    public BattleManager bm;


    private void Awake()
    {
        ac = GetComponent<ActorController>();
        GameObject sensor = transform.Find("sensor").gameObject;
        bm = sensor.GetComponent<BattleManager>();
        if (bm == null)
        {
            bm = sensor.AddComponent<BattleManager>();
        }

        bm.am = this;
    }


    private void Update()
    {
    }

    public void DoDamage()
    {
        ac.IssueTrigger("hit");
    }
}