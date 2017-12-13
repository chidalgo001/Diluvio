using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    private Vector2 direction;

    private Rigidbody2D body;

    private float timer;
    private float duration;

    [SerializeField]
    private float mintime;
    [SerializeField]
    private float maxtime;
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject drop;
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private Transform cPosition;


    // Use this for initialization
    void Start()
    {
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
                }

                SpawnDrop();
                SetRandomTimer();
            }
             
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

    private void SpawnCoin()
    {
        GameObject coinDrop = (GameObject)Instantiate(coin, cPosition.position, Quaternion.identity);
        coinDrop.GetComponent<CloudDrop>().Initialize(Vector2.down);

        timer = 0;
    }

    //This sets a random number 
    private void SetRandomTimer()
    {

        duration = Random.Range(mintime, maxtime);
    }

    // the cloud will dissapear/ destroy when the cloud leaves the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void DropCoin()
    {

    }
}
