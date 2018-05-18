using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public float timeLeft;
    public bool timerIsActive;

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

            if (timeLeft < 0.0f)
            {
                StopTimer();
                GameObject.Find("InGameUI").SendMessage("LosingScreen");
            }

            SetTimerText();
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
        if (timerIsActive)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }

    public void StartTimer ()
    {
        timerIsActive = true;
        timerText.color = new Color32(255, 255, 255, 255); // White
    }

    public void StopTimer()
    {
        timerIsActive = false;
        timerText.color = new Color32(128, 128, 128, 255); // Gray
    }
}
