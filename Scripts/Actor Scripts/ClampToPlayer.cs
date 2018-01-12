using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToPlayer : MonoBehaviour {

    private Transform playerPosition;
    private GameObject player;
    private Animator playerAnimator;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerPosition = player.GetComponent<Transform>();
        playerAnimator = player.GetComponent<Animator>();
	}
	
	void LateUpdate () {

        if (playerPosition && !playerAnimator.GetBool("Death"))
        {
            transform.position = new Vector3(Mathf.Clamp(playerPosition.position.x + .02f, 0, 100),
                Mathf.Clamp(playerPosition.position.y + 1.1f, 0, 100), transform.position.z);
        }

	}
}
