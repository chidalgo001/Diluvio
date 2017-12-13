using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text countText;
    public Text finalScore;

    private int score;
    private Transform target;
    private float timer;

    [SerializeField]
    private float limit;
    [SerializeField]
    private Animator playerAnimator;
    
	// Use this for initialization
	void Start () {

        finalScore.text = " ";
        target = GameObject.Find("Main Camera").transform;
        score = 0;
        SetScore();
        timer = 0;
	}

    // Update is called once per frame

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > limit)
        { 
            timer = 0;
            if(playerAnimator.GetBool("Death") == false)
                score++;
            SetScore();
            
        }
        
    }
    void FixedUpdate () {

        if (target)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x + 11, (float)24.5, (float)26.5),
                Mathf.Clamp(target.position.y + 4, (float)9.5, (float)9.5), transform.position.z);
        }

	}

    private void SetScore()
    {
        countText.text = score.ToString();
        if (playerAnimator.GetBool("Death") == true)
        {
            GameManager.control.SetHighScore(score);
            GameManager.control.Save();
            finalScore.text ="Final Score: " + score.ToString();
        }
    }
}
