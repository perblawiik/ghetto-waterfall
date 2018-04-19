using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectCollector : MonoBehaviour {

    private int collectCount;

	// Use this for initialization
	void Start () {
        collectCount = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            ++collectCount;
            other.gameObject.SetActive(false);
        }
    }
}
