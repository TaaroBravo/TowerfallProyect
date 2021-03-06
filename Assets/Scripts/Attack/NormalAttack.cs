﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : IAttack
{
    public NormalAttack(PlayerController pl, float _timerCoolDown = 0)
    {
        player = pl;
        timerCoolDownAttack = _timerCoolDown;
        coolDownAttack = _timerCoolDown;
        weaponExtends = 4;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Attack(Collider col)
    {
        if(timerCoolDownAttack < 0)
        {
            Debug.Log("Normal_J");
            Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents * weaponExtends, col.transform.rotation, LayerMask.GetMask("Hitbox"));
            foreach (Collider c in cols)
            {
                if (CheckParently(c.transform))
                    continue;
                //Hacer daño
                PlayerTwoTest target = TargetScript(c.transform);
                if (target != null)
                    target.ReceiveDamage("Normal");
            }
            timerCoolDownAttack = coolDownAttack;
        }
    }
}
