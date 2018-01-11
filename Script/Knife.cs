using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Knife : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private Enemy enemy;

    private Collider2D enemyCol;
    private Animator Anim;
    private Rigidbody2D rigid;

    private Vector2 direction;

	// Use this for initialization
	void Start () {

        rigid = GetComponent<Rigidbody2D>();
        enemyCol = enemy.GetComponent<Collider2D>();
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rigid.velocity = direction * speed;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Collider2D>() == enemyCol)
        {
            enemy.Anim.SetBool("death", true);
        }
    }

    private void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
