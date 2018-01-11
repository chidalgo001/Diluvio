using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Main : MonoBehaviour {

    public Animator Anim { get; private set; }
    public bool Atck { get; set; }

    [SerializeField]
    protected Transform knifePos;

    [SerializeField]
    protected int health;

    public abstract bool IsDead { get; }

    [SerializeField]
    protected float movementSpeed;

    [SerializeField]
    protected GameObject knifePrefab;

    protected bool faceRight;

    // Use this for initialization
    public virtual void Start () {
        Anim = GetComponent<Animator>();
        faceRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeDirection()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

    public virtual void ThrowKnife(int val) //the 'virtual' makes the function able to be overitten
    {
        if (faceRight)
        {
            GameObject temp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.identity);
            temp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else
        {
            GameObject temp = (GameObject)Instantiate(knifePrefab, knifePos.position,
                Quaternion.Euler(new Vector3(0, 0, 180)));

            temp.GetComponent<Knife>().Initialize(Vector2.left);
        }
    }

 
}
