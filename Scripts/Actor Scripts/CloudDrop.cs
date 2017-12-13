using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrop : MonoBehaviour {

    [SerializeField]
    private float speed;
    
    private Vector2 direction;

    private Rigidbody2D droplet;


	// Use this for initialization
	void Start () {
 
        droplet = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

       droplet.velocity = speed * direction;

	}


    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }

    //When the cloud drop touches the ground, it will be destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.gameObject.name == "Ground" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.name == "Player")
        {
           
        }


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
