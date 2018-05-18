using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    private GameObject pauseMenu;
    private Graphic backgroundImage;
    private TextMeshProUGUI gameOverMessage;
    private bool gameOver;
    private float animationTimer;
    private const float ANIMATION_TIME = 4.0f;
    private GameObject player;

    void Start ()
    {
        Time.timeScale = 1;
        player = GameObject.Find("Player").gameObject;
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        backgroundImage = GameObject.Find("UIBackground").GetComponent<Graphic>();
        gameOver = false;
        animationTimer = 0.0f;
       
        gameOverMessage = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverMessage.gameObject.SetActive(false);
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
            if ( (animationTimer / ANIMATION_TIME) < 1.5f)
            {

                animationTimer += Time.deltaTime;
                backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, animationTimer / ANIMATION_TIME);
            }
            else
            {
                // Remove game over message
                gameOverMessage.gameObject.SetActive(false);
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
        player.GetComponentInChildren<Dot_Truck_Controller>().PauseAudio();
        if (!gameOver)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.7f);
        }
        
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        player.GetComponentInChildren<Dot_Truck_Controller>().UnPauseAudio();
        if (!gameOver)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        // Stop shopping cart audio
        player.GetComponentInChildren<Dot_Truck_Controller>().PauseAudio();
        // Remove floor
        GameObject.Find("StoreBase").gameObject.SetActive(false);
        // Set game over message
        gameOverMessage.SetText("You ran out of time!");
        gameOverMessage.gameObject.SetActive(true);
        gameOver = true;
    }
}
