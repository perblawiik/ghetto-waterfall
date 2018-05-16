using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollector : MonoBehaviour {

    private int scoreCount;
    public TextMeshProUGUI scoreTextUI;
    public TextMeshPro scoreText3D;
    private bool text3DIsVisible;
    private float animationTimer;
    private GameObject scoreDisplayObject;
    private const float ANIMATION_TIME = 0.5f;

    // Use this for initialization
    void Start()
    {
        scoreDisplayObject = GameObject.Find("ScoreDisplay").gameObject;
        text3DIsVisible = false;
        animationTimer = 0.0f;
        scoreCount = 0;
        SetScoreText();
    }

    void Update()
    {
        if (text3DIsVisible)
        {
            animationTimer -= Time.deltaTime;

            // Make the text face the camera
            scoreDisplayObject.transform.LookAt(Camera.main.transform);
            scoreDisplayObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
            // Fade out the text
            Color colorUpdate = scoreText3D.color;
            colorUpdate.a = (animationTimer / ANIMATION_TIME);
            scoreText3D.color = colorUpdate;

            if (animationTimer < 0.0f)
            {
                text3DIsVisible = false;
            }
        }
    }

    void SetScoreText()
    {
        scoreTextUI.SetText("Score: " + scoreCount.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreObject"))
        {
            // Copy an instance of the score object
            ScoreObject scoreObject = other.gameObject.GetComponent(typeof(ScoreObject)) as ScoreObject;
            if (scoreObject.isClaimed == false)
            {
                scoreObject.isClaimed = true;

                // Add score value from object
                scoreCount += scoreObject.GetScoreValue();
                // Update score in UI
                SetScoreText();
                // Display score number as 3D text
                DisplayScore(scoreObject.GetScoreValue(), scoreObject.transform.position);

                // Scale down object
                scoreObject.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);

                // Move object to player
                Rigidbody rb = other.gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
                rb.transform.position = GameObject.Find("Basket").transform.position;
                rb.isKinematic = false;
                other.isTrigger = false;
            }
        }
    }

    private void DisplayScore(int score, Vector3 position)
    {
        text3DIsVisible = true;

        scoreDisplayObject.transform.position = position + new Vector3(0.0f, 1.5f, 0.0f);

        scoreText3D.SetText("+" + score.ToString());
        animationTimer = ANIMATION_TIME;
    }
}
