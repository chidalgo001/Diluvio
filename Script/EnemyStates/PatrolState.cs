using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

    private float patrolTimer;
    private float patrolDuration = 3f;
    private Enemy enemy1;

    public void Enter(Enemy enemy)
    {
        this.enemy1 = enemy;
    }

    public void Execute()
    {
        
        Patrol();
        enemy1.Move();
        if(enemy1.Target != null && enemy1.InThrowRange)
        {
            enemy1.ChangeState(new MeleeState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Edge")
        {
            enemy1.ChangeDirection();
        }
    }

    private void Patrol()
    {
        

        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            
            enemy1.ChangeState(new IdleState());
            
        }
    }
}
