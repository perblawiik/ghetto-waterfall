using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;
    GameObject timerTrigger;

    private void Start()
    {
        timerTrigger = GameObject.Find("TimerTrigger").gameObject;
    }


    // Use this for initialization
    void Awake () {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        float dist = Vector3.Distance(transform.parent.position, timerTrigger.transform.position);

     
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit) && Mathf.Abs(dist) > 7)
        {
            distance = Mathf.Clamp((hit.distance * 0.9f), minDistance, maxDistance);

        }
        else
        {
            distance = maxDistance;
        }


        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);

		
	}
}
