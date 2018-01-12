using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    //[SerializeField]
    public Animator player;// this is used to get the animator values from player

    [SerializeField]
    private Transform cloudPosition; //where to spawn

    [SerializeField]
    private GameObject cloud; //what to spawn

    [SerializeField]
    private float mintime;
    [SerializeField]
    private float maxtime;

    [SerializeField]
    private string Spawn_direction;// determine the direction in which to spawn the cloud

    private float timer;
    private float duration;


    // Use this for initialization
    void Start()
    {
        SpawnCloud();
        SetRandomTime();// sets the random duration at the beggigning

    }

    // Update is called once per frame
    void FixedUpdate()
    {

            if (player && player.GetBool("Death") == false)//this will spawn clouds only if alive.
            {
                timer += Time.deltaTime;
                if (timer > duration)
                {
                    SpawnCloud();
                    SetRandomTime();//sets random duration after initialization
                }

            }

    }//end fixupdate


    private void SpawnCloud()
    {

        float randomYpos = cloudPosition.position.y + Random.Range(-1, 1);
        Vector3 spawnPos = new Vector3(cloudPosition.position.x, randomYpos, cloudPosition.position.z);

        GameObject cloudspawn = (GameObject)Instantiate(cloud, spawnPos, Quaternion.identity);
        //gets an instance of the 'gameobject' given as param

        if (Spawn_direction == "left")
        {
            cloudspawn.GetComponent<Cloud>().Initialize(Vector2.left);
        }
        else
        {
            cloudspawn.GetComponent<Cloud>().Initialize(Vector2.right);
        }


        timer = 0;
    }

    private void SetRandomTime()
    {
        duration = Random.Range(mintime, maxtime);
    }

}
