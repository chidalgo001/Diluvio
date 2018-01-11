using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character_Main {

    private IEnemyState currentState;

    [SerializeField]
    private float meleeRange , throwRange;

    public bool InMelleRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }

            return false;

        }
            
    }

    public bool InThrowRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
            }

            return false;

        }

    }

    public GameObject Target { get; set; }

    public override bool IsDead
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    // Use this for initialization
    public override void Start () {


        base.Start();
        ChangeState(new IdleState());
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentState.Execute();
        LookAtTarger();

	}

    public void Move() {

        if( !Atck )
        {
            Anim.SetFloat("speed", 1);

            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));

        }

    }

    public Vector2 GetDirection()
    {
        return faceRight ? Vector2.right : Vector2.left;
    }

    public void ChangeState( IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();

        }

        currentState = newState;

        currentState.Enter(this);
    }

    private void LookAtTarger()
    {
        if(Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if( xDir < 0 && faceRight || xDir > 0 && !faceRight)
            {
                ChangeDirection();
            }
        }
    }

    void OnTriggerEnter2D( Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }


}
