using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour {

    public int scoreValue;
    private Vector3 startPosition;
    public bool isClaimed;

    void Start()
    {
        startPosition = transform.position;
        isClaimed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClaimed == false)
        {
            transform.position = startPosition + (new Vector3(0, (Mathf.Sin(Time.time)/4.0f), 0));
            transform.Rotate(new Vector3(0, 35, 0) * Time.deltaTime);
        }
    }

    public int GetScoreValue()
    {
        return scoreValue;
    }
}
