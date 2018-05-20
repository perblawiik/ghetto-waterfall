using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotation : MonoBehaviour {

    public float speed;

	
	// Update is called once per frame
	void Update ()
    {
   transform.Rotate(Vector3.back * Time.deltaTime*speed);
	}
}
