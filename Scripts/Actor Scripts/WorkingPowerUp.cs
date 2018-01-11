using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingPowerUp : MonoBehaviour {

    [SerializeField] 
    int durability;

    private GameManager control;

	// Use this for initialization
	void Start () {

        control = GameManager.control;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(durability == 0)
        {
            control.inUse = false;
            Destroy(gameObject);            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            durability -= 1;
        }
    }
}
