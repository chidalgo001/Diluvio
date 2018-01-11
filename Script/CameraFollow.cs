using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float xmax , xmin;
    [SerializeField]
    private float ymax , ymin;

    private Transform target;


	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xmin, xmax) ,
            Mathf.Clamp(target.position.y, ymin, ymax) , transform.position.z);
	}
}
