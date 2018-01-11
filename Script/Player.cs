using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character_Main {// the : is the same as extends
    
    private Rigidbody2D rigid;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool grounded , jump , revive;

    [SerializeField]
    private float jumpForce;

    private float timePause, duration;

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
        duration = 1.2f;
        revive = false;
        //this referenecs the 'RigidBody2d' from the player
        rigid = GetComponent<Rigidbody2D>();
        

	}

    private void Update()
    {
        Pause();
        HandleInput();
    }

    // Update is called once per frame
    //FixedUpdate updates a fixed amount of times depending on timestep.(use this for movement)
    void FixedUpdate () {

        float horizontal = Input.GetAxis( "Horizontal" );

        grounded = IsGrounded();
        
        if( revive != false)
        {
            HandleMovement( horizontal );

            Flip( horizontal );
        }
        
        _Reset();

        Anim.ResetTrigger( "Attack" );
	}

    //
    private void HandleMovement( float horizontal )
    {
        
        rigid.velocity = new Vector2( horizontal * movementSpeed, rigid.velocity.y );
        Anim.SetFloat( "speed_", Mathf.Abs( horizontal ) );

        if(grounded && jump)
        {
            grounded = false;
            rigid.AddForce(new Vector2( 0, jumpForce ) );
        }

    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !faceRight || horizontal < 0 && faceRight )
        {
            ChangeDirection();  
        }


    }
    
    // you can better this by having this checks trigger the calls on the animations 
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Anim.SetTrigger("Attack");
            
        }
    }

    private bool IsGrounded()
    {
        if (rigid.velocity.y <= 0)// this checks if we are falling down or not moving( the zero)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);  

                for( int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void _Reset()
    {
        jump = false;
    }


    
    private void Pause()
    {
        revive = Anim.GetBool("revive");

    }




    //make the animation spawn the knife, nt the player, in order to stop the spamming

}
