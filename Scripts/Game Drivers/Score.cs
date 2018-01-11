using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script is located under "Score" object in any of the levels
/// </summary>
public class Score : MonoBehaviour {

    public Text countText;
    public Text finalScore;

    private int score;
    private Transform target;
    private float timer;
    private GameManager control;

    [SerializeField]
    private float limit;

    [SerializeField]
    private int ScoreLimIce; //Total Score to unlock Ice level

    [SerializeField]
    private int ScoreLimFire;//Total Score to unlock Fire lvl

    [SerializeField]
    private int ScoreLimPoison;//Total Score to unlock Poison lvl

    [SerializeField]
    private Animator playerAnimator;
    
	// Use this for initialization
	void Start () {

        control = GameManager.control;
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
        if (control.levelID == 1 && score >= ScoreLimIce)
            control.UnlockLevel(2);
        else if (control.levelID == 2 && score >= ScoreLimFire)
            control.UnlockLevel(3);
        else if (control.levelID == 3 && score >= ScoreLimPoison)
            control.UnlockLevel(4);

        countText.text = score.ToString();

        if (playerAnimator.GetBool("Death") == true)
        {
            control.SetHighScore(score);
            control.Save();
            finalScore.text ="Final Score: " + score.ToString();
        }
    }
}
