using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public float timeLeft;
    private float lastTime;

	// Use this for initialization
	void Start () {
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (timeLeft > 0.0f)
        {
            // Calculate delta time for each update
            float timePassed = Time.time - lastTime;
            // Update time interval
            lastTime = Time.time;

            timeLeft = timeLeft - timePassed;

            string minutes = ((int)timeLeft / 60).ToString();
            string seconds = (timeLeft % 60).ToString("f0"); // zero decimals

            timerText.text = minutes + " : " + seconds;
        }
	}
}
