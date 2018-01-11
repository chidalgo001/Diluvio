using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    private double duration;
    private double timer;

	// Use this for initialization
	void Start () {
        timer = 0;
        duration = .5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        timer += Time.deltaTime;
        if(timer >= duration )
        {
            Destroy(gameObject);
        }
	}


}
