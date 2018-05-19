using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameKeyboardEvent : MonoBehaviour {

    enum GameState { WIN, LOSE, ACTIVE };

    private GameObject pauseMenu;
    private GameObject highScores;
    private GameObject winScreenButtons;
    private Graphic backgroundImage;
    private TextMeshProUGUI gameOverMessage;
    private float animationTimer;
    private const float ANIMATION_TIME = 4.0f;
    private GameObject playerAudioControl;
    private GameState gameState;
    //private PlayerScoreProgress highScoreList;

    void Start ()
    {
        Time.timeScale = 1;
        playerAudioControl = GameObject.Find("Player").gameObject;

        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);

        highScores = GameObject.Find("WinScreen").gameObject;
        highScores.SetActive(false);

        winScreenButtons = GameObject.Find("WinScreenButtons").gameObject;
        winScreenButtons.SetActive(false);

        gameOverMessage = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverMessage.gameObject.SetActive(false);

        backgroundImage = GameObject.Find("UIBackground").GetComponent<Graphic>();
        animationTimer = 0.0f;

        //highScoreList = new PlayerScoreProgress();

        gameState = GameState.ACTIVE;
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

        if (gameState != GameState.ACTIVE)
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

                if (gameState == GameState.LOSE)
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
                else if (gameState == GameState.WIN)
                {
                    highScores.SetActive(true);
                    winScreenButtons.SetActive(true);
                }
                
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        playerAudioControl.GetComponentInChildren<Dot_Truck_Controller>().PauseAudio();
        if (gameState == GameState.ACTIVE)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.7f);
        }
        
        pauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        playerAudioControl.GetComponentInChildren<Dot_Truck_Controller>().UnPauseAudio();
        if (gameState == GameState.ACTIVE)
        {
            backgroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        pauseMenu.SetActive(false);
    }

    public void LosingScreen ()
    {
        // Remove floor
        GameObject.Find("StoreBase").gameObject.SetActive(false);
        // Set game over message
        gameOverMessage.SetText("You ran out of time!");

        gameState = GameState.LOSE;
        EndGame();
    }

    public void WinScreen ()
    {
        ScoreCollector temp = GameObject.Find("Player").GetComponentInChildren<ScoreCollector>();

        PlayerScoreProgress tmp = highScores.GetComponentInChildren<PlayerScoreProgress>();
        tmp.AddScore(temp.GetScoreCount());
        
        //PlayerPrefs.SetInt("HighScores", temp.GetScoreCount());
        // Set game over message
        gameOverMessage.SetText("You finished with " + temp.GetScoreCount() + " points!");

        gameState = GameState.WIN;
        EndGame();
    }

    public void EndGame()
    {
        // Stop shopping cart audio
        playerAudioControl.GetComponentInChildren<Dot_Truck_Controller>().PauseAudio();
        gameOverMessage.gameObject.SetActive(true);
    }
}
