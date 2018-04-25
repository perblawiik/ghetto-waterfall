using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour {

    public int scoreValue;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
    }

    public int GetScoreValue()
    {
        return scoreValue;
    }
}
