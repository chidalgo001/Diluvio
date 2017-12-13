using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour {

    public Button yourButton; //this is to assign the button.
    public bool displayWindow = false;
    public GUISkin mySkin;
    public string message;
    public int coinsNeeded;

    private int coins;
    private Animator animator;
    private GameManager control;
    int xsize, ysize;
    
    [SerializeField]
    private int ID;

	void Start () {

        xsize = Screen.width / 2;
        ysize = Screen.height / 2;

        control = GameManager.control;

        yourButton.onClick.AddListener(TaskOnClick);

        animator = gameObject.GetComponent<Animator>();
        //myStyle.fontSize = Screen.height / 25;
        mySkin.button.fontSize = Screen.height / 25;
        mySkin.label.fontSize = Screen.height / 25;

        if (ID != 1)
            animator.SetBool("Unlock", control.IsUnlocked(ID));
    }
    
    // Update is called once per frame
    void Update () {
		animator.SetBool("Unlock", control.IsUnlocked(ID));
        coins = control.coins;
	}

    public void TaskOnClick()
    {
        control.SetPlayerID(ID);
        
        if (animator.GetBool("Unlock") == true)
        {
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            displayWindow = !displayWindow;
        }        
    }

    private void OnGUI()
    {
        GUI.skin = mySkin;
        if (displayWindow)
            GUI.Window(0, new Rect(xsize - (xsize / 2), ysize - (ysize / 6), xsize, ysize / 2),
                ShowWindow, "");// this window will keep the same ratio regarding of screen size.
    }

    //this funtion is the one called in the wondow. everything in here will be displayed in the window.
    private void ShowWindow(int windowID)
    {
        int temp = 0;
        temp = coins - coinsNeeded;
        string message = "";

        if(coins >= coinsNeeded)
        {
            message = "Yes. Here you go, " + coinsNeeded.ToString() + " coins.";
        }
        else
        {
            message = "I'm missing " + (coinsNeeded - coins).ToString() + " coin(s).";
        }

        GUI.Label(new Rect(30, 30, xsize - 60 , Screen.height / 25),"Want to unlock?");

        if(GUI.Button(new Rect(30, (ysize/2 - ysize/4), xsize - 60, (ysize * 0.25f) - 60), message))
        {


            if (temp >= 0)
            {
                if (!control.IsUnlocked(ID))//this will update the coins only if the player is not unlocked
                {
                    control.coins = temp;// store the remaining coins into the game.
                    animator.SetBool("Unlock", true);
                    displayWindow = false;

                }

                control.UnlockCharacter(ID);

            }
            else
            {
                displayWindow = false;
            }
        }


    }


}
