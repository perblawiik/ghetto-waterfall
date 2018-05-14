using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    private GameObject pauseMenu;
    private Graphic backgroundImage;
    private bool gameOver;
    private float a;

    void Start ()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        backgroundImage = GameObject.Find("UIBackground").GetComponent<Graphic>();
        gameOver = false;
        a = 0.0f; 
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

        if (gameOver)
        {
            // Black fade out
            if ( (a / 5.0f) < 1.0f)
            {
                a += Time.deltaTime;
                backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, a / 4.0f);
            }
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

    public void EndGame()
    {
        GameObject.Find("StoreBase").gameObject.SetActive(false);
        gameOver = true;
    }
}
