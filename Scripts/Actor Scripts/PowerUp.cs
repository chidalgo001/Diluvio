using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private GameManager control;

    private float timer;
    private float duration; //time for a PU to disappear.

    private bool rotate;

    private int rotationSpeed;

	// Use this for initialization
	void Start () {

        rotationSpeed = Random.Range(45, 90);

        if(rotationSpeed % 2 == 0)
        {
            rotationSpeed = -( rotationSpeed ) ;
        }//This makes the Power up either 'fall' to the left or right.

        rotate = true;
        control = GameManager.control;
        duration = 4;
	}
	
	// Update is called once per frame
	void Update () {

        if (rotate)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        }//will let the item rotate as it falls.

        timer += Time.deltaTime;
        control.inUse = true;

        if (timer > duration)
        {
            control.inUse = false;// doesnt allow the spawning of other powerUps
            Destroy(gameObject);

        }// this will destroy the object after 'duration' seconds.
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);            
        }
        else if (other.gameObject.name == "Ground")
        {
            rotate = false;
        }
    }

       
}
