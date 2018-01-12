using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour {

    public Animator player;
    public Button yourButton;
    private Animator anim;

    void Start()
    {
        anim = yourButton.GetComponent<Animator>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    private void FixedUpdate()
    {
        if (player.GetBool("Death") == true)
        {
            anim.SetBool("Reset", true);
        }
    }

    void TaskOnClick()
    {
        GameManager.control.inUse = false;
        anim.SetBool("Reset", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
