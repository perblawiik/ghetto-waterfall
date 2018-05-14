using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    private GameObject pauseMenu;
    private Graphic backgroundImage;
    private bool gameOver;
    private float animationTimer;
    private const float ANIMATION_TIME = 4.0f;

    void Start ()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        backgroundImage = GameObject.Find("UIBackground").GetComponent<Graphic>();
        gameOver = false;
        animationTimer = 0.0f; 
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
            // Fade to black
            if ( (animationTimer / ANIMATION_TIME) < 1.0f)
            {
                animationTimer += Time.deltaTime;
                backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, animationTimer / ANIMATION_TIME);
            }
            else
            {
                // Open pause menu
                PauseGame();

                // Deactivate continue button
                Button continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
                continueButton.interactable = false;
                continueButton.image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

                // Set visual effect for deactivated button
                TextMeshProUGUI temp = continueButton.GetComponentInChildren<TextMeshProUGUI>();
                Color c = temp.color;
                c.a = 0.1f;
                temp.color = c;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (!gameOver)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.7f);
        }
        
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        if (!gameOver)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        GameObject.Find("StoreBase").gameObject.SetActive(false);
        gameOver = true;
    }
}
