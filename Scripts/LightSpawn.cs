using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawn : MonoBehaviour {

    private double duration;
    private double timer;
    private bool spawned;

    [SerializeField]
    private GameObject lightning;
    [SerializeField]
    private Transform selfPosition;
    // Use this for initialization
    void Start()
    {
        spawned = false;
        timer = 0;
        duration = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.deltaTime;
        if (timer >= duration && !spawned)
        {
            spawned = true;
            Instantiate(lightning,new Vector3(selfPosition.position.x, selfPosition.position.y - 4
                ,selfPosition.position.z), Quaternion.identity);
        }
        if ( timer >= (duration + .5) )
            Destroy(gameObject);
    }

}
