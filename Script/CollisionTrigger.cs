using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {

    private BoxCollider2D playerColider;

    [SerializeField]
    private BoxCollider2D platformCollider;// this is the platform the player needs to land on

    [SerializeField]
    private BoxCollider2D platformTrigger;


	// Use this for initialization
	void Start () {

        playerColider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, platformTrigger, true);
	}

    void OnTriggerEnter2D( Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerColider, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(platformCollider, playerColider, false);
        }
    }


}
