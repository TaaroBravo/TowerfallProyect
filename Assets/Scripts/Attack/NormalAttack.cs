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
        weaponExtends = player.weaponExtends;
        impactVelocity = player.impactVelocityNormal;
        defaultAttack = player.defaultAttackNormal;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Attack(Collider col)
    {
        if (timerCoolDownAttack < 0)
        {
            Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents * weaponExtends, col.transform.rotation, LayerMask.GetMask("Hitbox"));
            foreach (Collider c in cols)
            {
                if (CheckParently(c.transform))
                    continue;
                PlayerController target = TargetScript(c.transform);
                player.myAnim.Play("Attack02");
                player.hitParticles.Play();
                if (target != null)
                    target.ReceiveDamage(new Vector3(Mathf.Sign(player.transform.forward.x) * impactVelocity * Mathf.Abs(player.moveVector.x == 0 ? defaultAttack : player.moveVector.x), 0, 0));
            }
            timerCoolDownAttack = coolDownAttack;
        }
    }
}