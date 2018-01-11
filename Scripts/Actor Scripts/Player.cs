using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rigid;
    private Animator anim;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private GameObject dust;

    [SerializeField]
    private GameObject powerUp;

    [SerializeField]
    private GameObject[] list;

    private Transform trans;

    private bool faceRight, ableMovement;
    private float timer;

    private bool isAndroid = false;
 
    private void Awake()
    {
 #if UNITY_ANDROID
        isAndroid = true;
     
        #endif       
    }
    // Use this for initialization
    void Start () {
        timer = 0;

        anim = GetComponent<Animator>();

        DetermineAnim(GameManager.control.GetPlayerID());
        faceRight = true;
        ableMovement = true;
        rigid = GetComponent<Rigidbody2D>();//gets its own rigid.

        trans = gameObject.transform;

    }
	
	// Update is called once per frame
	private void Update () {

        if (anim.GetFloat("speed") > 0.1 && !anim.GetBool("Death"))
        {
            timer += Time.deltaTime;
            if (timer > 0.25f)
            {
                SpawnDust();
            }
        }

    }

    private void FixedUpdate()
    {
            float movement = Input.GetAxis("Horizontal");

            if (ableMovement)
            {
                HandleMovement(movement);
            }

    }

    private void HandleMovement( float movement)
    {

        if (isAndroid)
        {
            AndroidMovementHandler();
        }
        else
        {
            PCMovementHandler(movement);
        }        
    }

    private void AndroidMovementHandler()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            anim.SetFloat("speed", Mathf.Abs(movementSpeed));

            if (touch.position.x > (Screen.width / 2) &&
                (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began))
            {

                if (!faceRight)
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);

                faceRight = true;
                rigid.velocity = new Vector2(movementSpeed, 0);

            }//if the position of the first touch is in the right half of the screen, move right.
            else
            if (touch.position.x < (Screen.width / 2) &&
                (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began))
            {

                if (faceRight)
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);

                faceRight = false;
                rigid.velocity = new Vector2(-movementSpeed, 0);

            }//if the position of the first touch is in the left half of the screen, move left.

        } 
        else
        {
            rigid.velocity = new Vector2(0, 0);
            anim.SetFloat("speed", 0);
        }// if no touch, set speed to 0
    }

    private void PCMovementHandler(float movement)
    {
        rigid.velocity = new Vector2(movementSpeed * movement, 0);

        anim.SetFloat("speed", Mathf.Abs(movement));

        if (movement > 0 && !faceRight || movement < 0 && faceRight)
        {
            faceRight = !faceRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);// rotates about the y axix (x,y,z)
        }

    }

    private void OnTriggerEnter2D(Collider2D drop)
    {
        if (drop.gameObject.tag == "Coin" && ableMovement)
        {
            GameManager.control.coins = GameManager.control.coins + 1;
        }

        else if (drop.gameObject.tag == "Drop" )//Drop is the tag name for everything that kills the player
        {
            if(drop.gameObject.name == "Lightning(Clone)")
            {
                Physics2D.IgnoreCollision(drop.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            anim.SetBool("isMoving", false);
            ableMovement = false;
            if (!anim.GetBool("Death"))
            {
              //  SpawnItem();
            }
            anim.SetBool("Death", true);
            anim.SetFloat("speed", 0);
            
        }else if (drop.gameObject.tag == "PowerUp")
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PowerUp")
        {
            Instantiate(powerUp, new Vector3(trans.position.x + .02f, trans.position.y + 1.1f,
                trans.position.z), Quaternion.identity);

        }
    }

    private void DetermineAnim(int Id)
    {
        if(Id == 1)
        {
            anim.SetTrigger("Main");

        }
        if(Id == 2)
        {
            anim.SetTrigger("Female");
            movementSpeed = movementSpeed + 1;
        }
        if (Id == 3)
        {
            anim.SetTrigger("Glasses");
            movementSpeed = movementSpeed + 3;
        }
        if (Id == 4)
        {
            anim.SetTrigger("TopHat");
            movementSpeed = movementSpeed - 1;
        }

    }

    private void SpawnDust()
    {
        Instantiate(dust, new Vector3(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y - 0.65f,
            gameObject.transform.position.z), Quaternion.identity);
        timer = 0;
    }

    private void SpawnItem()
    {
        int item_number = GameManager.control.GetPlayerID() - 1;

        Instantiate(list[item_number], new Vector3(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y - 0.65f,
            gameObject.transform.position.z), Quaternion.identity);
    }


}
