using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoScript : MonoBehaviour {

    public bool displayWindow = false;
    public string message;
    public int ID;
    public GUIStyle myStyle;
    public float toggleX, toggleY, windowX, windowY;
    public Transform trans;

    private int coinsNeeded;


    private void Start()
    {       
       
        if (!GameManager.control.IsUnlocked(ID))
            message = message + "\n\nCoins Needed: " + coinsNeeded.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnGUI()
    {        
        displayWindow = GUI.Toggle(new Rect(trans.position.x + toggleX, trans.position.y + toggleY, 80, 80),
            displayWindow, "");
    }

    //this funtion is the one called in the wondow. everything in here will be displayed in the window.
    private void ShowWindow(int windowID)
    {
        GUI.Label(new Rect(10, 30, 290, 170), message, myStyle);
    }

    //both functions below able and disable the window showing the info
    private void OnMouseEnter()
    {
        displayWindow = true;
    }

    private void OnMouseExit()
    {
        displayWindow = false;
    }

}
