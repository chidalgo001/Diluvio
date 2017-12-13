using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour {

    public Button myButton;
	// Use this for initialization
	void Start () {
        myButton.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        GameManager.control.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
