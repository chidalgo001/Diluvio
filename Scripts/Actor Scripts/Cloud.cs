using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    private Vector2 direction;

    private Rigidbody2D body;
    private GameManager control;

    private int randomNumber;
    private float timer;
    private float duration;//the rate at wich the raindrops fall

    [SerializeField]
    private float mintime; // the minimum time the drop can fall 
    [SerializeField]
    private float maxtime; // the max time the drop can fall
    [SerializeField]
    private float speed; // speed of the drop at which it falls

    [SerializeField]
    private GameObject drop;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject powerUp;

    //Spawners for each level
    [SerializeField]
    private GameObject lightningSpawner;
    [SerializeField]
    private GameObject iceSpawner;
    [SerializeField]
    private GameObject lavaSpawner;
    //----------------------------

    [SerializeField]
    private Transform cPosition; //position of the clouds, used to determine the spawn point of objects


    // Use this for initialization
    void Start()
    {
        control = GameManager.control;
        body = GetComponent<Rigidbody2D>();
        SetRandomTimer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            timer += Time.deltaTime;
            body.velocity = speed * direction;

            if(timer > duration)
            {
                if( (duration > 0.5f) && (duration < 0.53f) )
                {                    
                    SpawnCoin();
                }//The timer for the cloud to spawn the coins
                else if( duration > 0.95f && duration < 0.97f)
                {
                    SpawnLevelFactor(control.levelID);
                }//The timer for the cloud to spawn the spawner for each level
                
                if (duration > 0.85f && duration < 0.86f)                                {
                    SpawnPowerUp();
                }//The timer for the cloud to spawn the spawner for each level
                SpawnDrop();
                SetRandomTimer();
            }//This is the overall timer for the drop to spawn a droplet
             
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    //Spwns the cloud drop from the cloud at random intervals from the cloud
    private void SpawnDrop()
    {
        GameObject cDrop = (GameObject)Instantiate(drop, cPosition.position, Quaternion.identity);
        cDrop.GetComponent<CloudDrop>().Initialize(Vector2.down);

        timer = 0;
    }

    //This spawns the extra thing that hurts the player in the level
    private void SpawnLevelFactor(int level)
    {

        if (level == 1)
            Instantiate(lightningSpawner, cPosition.position, Quaternion.identity);        
        else if (level == 2)
        {
            if(iceSpawner)
                Instantiate(iceSpawner, cPosition.position, Quaternion.identity);
        }

        else if (level == 3)
        {
            if (lavaSpawner)
                Instantiate(lavaSpawner, cPosition.position, Quaternion.identity);
        }


    }//This will select what to spawn depending on the level you are on,

    private void SpawnCoin()
    {

        GameObject coinDrop = (GameObject)Instantiate(coin, cPosition.position, Quaternion.identity);
        coinDrop.GetComponent<CloudDrop>().Initialize(Vector2.down);

        timer = 0;
    }

    private void SpawnPowerUp()
    {
        if(!control.inUse)
            Instantiate(powerUp, cPosition.position, Quaternion.identity);
    }

    //This sets a random number 
    private void SetRandomTimer()
    {
        duration = Random.Range(mintime, maxtime);
    }

    // the cloud will disappear/ destroy when the cloud leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
