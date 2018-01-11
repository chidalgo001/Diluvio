using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private GameManager control;

    private float timer;

    private float duration; //time for a PU to disappear.

	// Use this for initialization
	void Start () {
        control = GameManager.control;
        duration = 4;

	}
	
	// Update is called once per frame
	void Update () {

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
    }

       
}
