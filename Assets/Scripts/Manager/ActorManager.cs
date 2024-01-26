using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public ActorController ac;
    public BattleManager bm;
    // public WeaponManager wm;
    public StateManager sm;

    private void Awake()
    {
        ac = GetComponent<ActorController>();
        GameObject model = ac.model;
        GameObject sensor = transform.Find("sensor").gameObject;
        bm = Bind<BattleManager>(sensor);
        // wm = Bind<WeaponManager>(model);
        sm = Bind<StateManager>(gameObject);
    }

    private T Bind<T>(GameObject go) where T : IActorManagerInterface
    {
        T tempInstance;
        tempInstance = go.GetComponent<T>();
        if (tempInstance == null)
        {
            tempInstance = go.AddComponent<T>();
        }

        tempInstance.am = this;
        return tempInstance;
    }

    public void SetIsCounterBack(bool value)
    {
        sm.isCounterBackEnable = value;
    }

    public void TryDoDamage(WeaponController targetWc, bool attackValid, bool counterValid)
    {
        if (sm.isCounterBackSuccess)
        {
            if (counterValid)
            {
                targetWc.wm.am.Stunned();
            }
        }
        else if (sm.isCounterBackFailure)
        {
            if (attackValid)
            {
                HitOrDie(false);
            }
        }
        else if (sm.isImmortal)
        {
        }
        else if (sm.isDefense)
        {
            Blocked();
        }
        else
        {
            if (attackValid)
            {
                HitOrDie(true);
            }
        }
    }

    public void Stunned()
    {
        ac.IssueTrigger("stunned");
    }

    public void Blocked()
    {
        ac.IssueTrigger("blocked");
    }

    public void HitOrDie(bool doHitAnimation)
    {
        if (sm.HP <= 0)
        {
        }
        else
        {
            sm.AddHP(-5);
            if (sm.HP > 0)
            {
                if (doHitAnimation)
                {
                    Hit();
                }
                //do some VFX, like splatter blood...
            }
            else
            {
                Die();
            }
        }
    }

    public void Hit()
    {
        ac.IssueTrigger("hit");
    }

    public void Die()
    {
        ac.IssueTrigger("die");
        ac.pi.inputEnabled = false;
        if (ac.camcon.lockState == true)
        {
            ac.camcon.LockUnlock();
        }

        ac.camcon.enabled = false;
    }
}