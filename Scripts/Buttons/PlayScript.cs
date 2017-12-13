using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {

    public Button YourButton;
    public Text buttonText;
    private GameManager control;
    private Rigidbody2D rigid;
    float power, initPos, finalPos;

	// Use this for initialization
	void Start () {
        initPos = gameObject.transform.position.x;
        finalPos = initPos + 12;

        control = GameManager.control;
        YourButton.onClick.AddListener(TaskOnCLick);

        }
	
	// Update is called once per frame
	void Update () {
        
        if (gameObject.transform.position.x < finalPos && control.options)
        {
            power = power + (Time.deltaTime * .5f);
            transform.Translate(power, 0, 0);

        }
        else if(gameObject.transform.position.x > initPos && !control.options)
        {
            power = power + (Time.deltaTime * .5f);
            transform.Translate(-power, 0, 0);
        }
        else
        {

            power = 0;
        }

            
        //Debug.Log(gameObject.transform.position.x);
    }

    private void TaskOnCLick()
    {
        
        if (buttonText.text == "Play!")
        {
            control.Load();
            SceneManager.LoadScene("PlayerSelect");
            
        }
        else if (buttonText.text == "Quit..")
            Application.Quit();
        else if (buttonText.text == "Options")
        {
            control.options = true;
            //SceneManager.LoadScene("Options");
        }
        else if (buttonText.text == "Back")
        {
            control.options = false;
        }            
        else if(buttonText.text == "Reset")
        {
            GameManager.control.ResetData();
        }
            
    }

}
