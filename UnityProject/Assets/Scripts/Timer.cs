using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public float startTime;
    private float initialTime;
    private float timeLeft;
    private bool stopTime;

	// Use this for initialization
	void Start () {
        initialTime = Time.time;
        stopTime = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!stopTime)
        {
            float timePassed = Time.time - initialTime;
            timeLeft = startTime - timePassed;

            string minutes = ((int)timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("f0"); // zero decimals

            timerText.text = minutes + " : " + seconds;

            if (timeLeft < 0.01 )
            {
                stopTime = true;
            }
        }
	}
}
