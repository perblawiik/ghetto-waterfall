using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAnimation : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.up * Mathf.Sin(Time.time) * 0.05f;
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
