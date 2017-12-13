using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustScript : MonoBehaviour {

    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer + Time.deltaTime;
        if(timer > 0.8f)
        {
            Destroy(gameObject);
        }
	}


}
