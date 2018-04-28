using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCollector : MonoBehaviour {

    private int scoreCount;
    public TextMeshProUGUI scoreText;

    // Use this for initialization
    void Start()
    {
        scoreCount = 0;
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.SetText("Score: " + scoreCount.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreObject"))
        {
            // Copy an instance of the score object
            ScoreObject temp = other.gameObject.GetComponent(typeof(ScoreObject)) as ScoreObject;
            // Add score value from object
            scoreCount += temp.GetScoreValue();
            // Remove object from scene
            other.gameObject.SetActive(false);
            SetScoreText();
        }
    }
}
