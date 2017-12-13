using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testing : MonoBehaviour {

    public bool doWindow0 = true;
    public string message;
    public GUIStyle myStyle;
    public float x, y;

    private void Start()
    {
       
    }

    void DoWindow0(int windowID)
    {
        GUI.Label(new Rect(10, 20, 180, 180), message, myStyle);
        
        if (GUI.Button(new Rect(50, 120, 100, 20), "Close"))
            doWindow0 = false;
    }

    void OnGUI()
    {        
        if (doWindow0)
            //GUI.Window(0, new Rect(110, 10, 200, 150), DoWindow0, "Basic Window", myStyle);
            GUI.Label(new Rect(x, y, 180, 180), message, myStyle);
    }

    private void OnMouseEnter()
    {
        doWindow0 = true;
        message = "I entered";
    }

    private void OnMouseExit()
    {
        doWindow0 = false;
    }
}
