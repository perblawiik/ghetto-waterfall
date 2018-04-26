using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
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
            }
        }
	}

    private void SetTimerText ()
    {
        string minutes = ((int)timeLeft / 60).ToString("00");
        string seconds = ((int)timeLeft % 60).ToString("00"); // zero decimals;
        timerText.text = minutes + " : " + seconds;
    }

    public void ToggleTimer ()
    {
        if (timerIsActive == false)
        {
            timerIsActive = true;
            timerText.color = Color.yellow;
        }
        else
        {
            timerIsActive = false;
            timerText.color = Color.gray;
        }
    }
}
