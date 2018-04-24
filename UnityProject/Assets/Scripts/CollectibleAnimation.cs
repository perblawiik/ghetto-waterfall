using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAnimation : MonoBehaviour {

    private float tickLimit;
    private float tickCount;

    void Start ()
    {
        tickLimit = 0.012f;
        tickCount = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        tickCount += Time.deltaTime;
        
        if (tickCount > tickLimit)
        {
            transform.position += Vector3.up * Mathf.Sin(Time.time*2.0f) * 0.01f;
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);

            tickCount = 0.0f;
        }
        
    }
}
