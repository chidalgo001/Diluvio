using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDisplayManager : MonoBehaviour {

    public Text highScore;
    public Text coins;
	// Use this for initialization
	void Start () {
        
        if(highScore != null && (SceneManager.GetActiveScene().name == "PlayerSelect"))
            highScore.text ="High Score: " + GameManager.control.score.ToString();
        coins.text = ": " + GameManager.control.coins.ToString();
	}
	
	// Update is called once per frame
	void Update () {

        //if (highScore != null)
        //    highScore.text = "High Score: " + GameManager.control.score.ToString();
        coins.text = ": " + GameManager.control.coins.ToString();
        
    }
}
