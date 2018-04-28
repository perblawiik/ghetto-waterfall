using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public float timeLeft;
    private bool timerIsActive;

    void Start ()
    {
        timerIsActive = false;
        SetTimerText();
    }
	
	// Update is called once per frame
	void Update () {

        if (timerIsActive == true)
        {
            timeLeft = timeLeft - Time.deltaTime;
            SetTimerText();

            if (timeLeft < 0.0f)
            {
                timerIsActive = false;
                timerText.color = new Color32(128, 128, 128, 255); // Gray
            }
        }
	}

    private void SetTimerText ()
    {
        string minutes = ((int)timeLeft / 60).ToString("00");
        string seconds = ((int)timeLeft % 60).ToString("00"); // zero decimals;

        timerText.SetText(minutes + " : " + seconds);
    }

    public void ToggleTimer ()
    {
        if (timerIsActive == false)
        {
            timerIsActive = true;
            timerText.color = new Color32(255, 255, 255, 255); // White
        }
        else
        {
            timerIsActive = false;
            timerText.color = new Color32(128, 128, 128, 255); // Gray
        }
    }
}
