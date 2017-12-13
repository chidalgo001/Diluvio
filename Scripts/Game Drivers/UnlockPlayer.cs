using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockPlayer : MonoBehaviour {
        
    public bool displayWindow = false;
    public int ID, coinsNeeded;
    public Button button;  
    public Animator animator;
    public float x, y;
    public GUIStyle myStyle;
    public GUISkin mySkin;

    public string message;

    private float duration = 3.0f;
    private float timer = 0;

    int xsize,ysize;
    

	// Use this for initialization
	void Start () {

        if (!GameManager.control.IsUnlocked(ID))
            message = message + "\n\nCoins Needed: " + coinsNeeded.ToString();    

        button.onClick.AddListener(TaskOnClick);
        xsize = Screen.width / 2;
        ysize = Screen.height / 2;
	}
	
	// Update is called once per frame
	void Update () {
        
        myStyle.fontSize = Screen.height / 25;

        if (displayWindow)
        {
            timer = timer + Time.deltaTime;
            if (timer > duration)
               displayWindow = false;

        }
        else
        {
            timer = 0;
        }
		
	}

    private void TaskOnClick()
    { 
        GameManager control = GameManager.control;

        displayWindow = true;

        control.SetPlayerID(ID);

    }

    private void OnGUI()
    {
        GUI.skin = mySkin;
        if (displayWindow)
            GUI.Window(0, new Rect(xsize - (xsize/2) ,ysize - (ysize/6), xsize, ysize/2),
                ShowWindow, "");// this window will keep the same ratio regarding of screen size.
    }

    //this funtion is the one called in the wondow. everything in here will be displayed in the window.
    private void ShowWindow(int windowID)
    {
        GUI.Label(new Rect(30, 30, xsize -60, (ysize / 2) - 60), message, myStyle);

  
    }


    
}
