using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_automation : MonoBehaviour {
    [SerializeField]
    GameObject door_L;
    [SerializeField]
    GameObject door_R;

    public float speed = 1.0f;

    public Transform startMarker_L;
    public Transform endMarker_L;

    public Transform startMarker_R;
    public Transform endMarker_R;

    private float startTime;
    private float journeyLength;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update () {
       


    }
    void open()
    {

    }
    void close()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        open();
    }
    void OnTriggerExit(Collider collider)
    {
        // Destroy everything that leaves the trigger
       close();
    }
}

