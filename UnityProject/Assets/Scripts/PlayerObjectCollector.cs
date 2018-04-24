using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectCollector : MonoBehaviour {

    private int collectCount;
    public Text countText;

	// Use this for initialization
	void Start () {
        collectCount = 0;
        SetCountText();
    }

    void SetCountText() {

        countText.text = "Score: " + collectCount.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            ++collectCount;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }
}
