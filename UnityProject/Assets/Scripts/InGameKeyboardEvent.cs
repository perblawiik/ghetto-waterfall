using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    private GameObject pauseMenu;

    void Start ()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        ContinueGame();
    }

	void Update ()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (pauseMenu.activeInHierarchy == false)
                PauseGame();
            else
                ContinueGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
