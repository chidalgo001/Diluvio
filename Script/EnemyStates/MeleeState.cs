using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState {


    private Enemy enemy;

    private float coolDown = 3;
    private float throwTimer;
    private bool canThrow = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {

        ThrowKnife();

        if(enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.Anim.ResetTrigger("Throw");
            enemy.ChangeState(new IdleState());
        }

        
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void ThrowKnife()
    {
        throwTimer += Time.deltaTime;

        if(throwTimer >= coolDown)
        {
            canThrow = true;
            throwTimer = 0;
        }

        if (canThrow)
        {
            canThrow = false;
            enemy.Anim.SetTrigger("Throw");
        }
    }


}
