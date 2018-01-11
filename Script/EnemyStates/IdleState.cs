using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState{

    private float idleTimer;
    private float idleDuration = 3f;
    private Enemy enemy1;

    public void Enter(Enemy enemy)
    {
        this.enemy1 = enemy;
    }

    public void Execute()
    {
        
        Idle();

        if(enemy1.Target != null)
        {
            enemy1.ChangeState(new PatrolState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    private void Idle()
    {
        enemy1.Anim.SetFloat("speed", 0);

        idleTimer += Time.deltaTime;

        if(idleTimer >= idleDuration)
        {
            enemy1.ChangeState(new PatrolState());
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
