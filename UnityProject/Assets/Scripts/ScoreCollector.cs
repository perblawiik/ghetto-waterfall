using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCollector : MonoBehaviour {

    private int scoreCount;
    public TextMeshProUGUI scoreText;

    //Sound
    AudioSource pickupSound;

    // Use this for initialization
    void Start()
    {
        scoreCount = 0;
        SetScoreText();
        var aSources = GetComponents<AudioSource>();
        pickupSound = aSources[0];
    }

    void playPickupSound()
    {
        pickupSound.Play();        
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
            ScoreObject scoreObject = other.gameObject.GetComponent(typeof(ScoreObject)) as ScoreObject;

            if (scoreObject.isClaimed == false)
            {
                scoreObject.isClaimed = true;
                Rigidbody rb = other.gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
                
                // Scale down object
                scoreObject.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);
                // Move object to player
                rb.transform.position = GameObject.Find("Basket").transform.position;
                rb.isKinematic = false;
                other.isTrigger = false;

                // Add score value from object
                scoreCount += scoreObject.GetScoreValue();
                // Update score in UI
                SetScoreText();
                pickupSound.Play();
            }

        }
    }
}
