using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    private GameObject pauseMenu;
    private Graphic backgroundImage;

    void Start ()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        backgroundImage = GameObject.Find("UIBackground").GetComponent<Graphic>();
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
        backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        pauseMenu.SetActive(false);
    }
}
