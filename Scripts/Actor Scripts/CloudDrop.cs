using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrop : MonoBehaviour {

    [SerializeField]
    private float speed;
    
    private Vector2 direction;

    private Rigidbody2D droplet;

    private GameManager control;

    [SerializeField]
    private Sprite iceDrop;
    [SerializeField]
    private Sprite fireDrop;
    [SerializeField]
    private Sprite poisonDrop;


    // Use this for initialization
    void Start () {

        control = GameManager.control;
        droplet = GetComponent<Rigidbody2D>();

        DetermineImage(control.levelID);

	}
	
	// Update is called once per frame
	void Update ()
    {

       droplet.velocity = speed * direction;

	}


    public void Initialize(Vector2 direction)
    {
        this.direction = direction;

    }


    /// This will determine the image of the "rain" drops depending on the level selected 
    /// <param name="level"></param>
    private void DetermineImage(int level)
    {
        if (level == 2)
        {
            GetComponent<SpriteRenderer>().sprite = iceDrop;
        }
        else if (level == 3)
        {
            GetComponent<SpriteRenderer>().sprite = fireDrop;
        }
        else if (level == 4)
        {
            GetComponent<SpriteRenderer>().sprite = poisonDrop;
        }
        else if (level == 5)
        {
            GetComponent<SpriteRenderer>().sprite = iceDrop;
        }
    }

    //When the cloud drop touches the ground, it will be destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.gameObject.name == "Ground" || other.gameObject.tag == "Player" ||
            other.gameObject.name == "umbrellaPU(Clone)")
        {
            Destroy(gameObject);
        }
    }

    //When the object leaves the camera, the object is destroyed
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
