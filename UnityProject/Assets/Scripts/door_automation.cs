using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_automation : MonoBehaviour {
    [SerializeField]
    GameObject door_L;
    [SerializeField]
    GameObject door_R;

    public float speed = 10f;

    public Vector3 startMarker_L;
    public Vector3 delta_L;

    public Vector3 startMarker_R;
    public Vector3 delta_R;


    private float journeyLength;
 

    bool open = false;
    bool close = false;

    void Start()
    {

        startMarker_L = door_L.transform.position;
        startMarker_R = door_R.transform.position;
    }
    void Update () {

        if (open)
        {
            var delta_R = Vector3.Magnitude(door_R.transform.position - startMarker_R);
            var delta_L = Vector3.Magnitude(door_L.transform.position - startMarker_L);

            if (delta_R < 6)
                door_R.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
            if (delta_L < 6)
                door_L.transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
        }

        if(close)
        {
            var delta_R = Vector3.Magnitude(door_R.transform.position - startMarker_R);
            var delta_L = Vector3.Magnitude(door_L.transform.position - startMarker_L);

            if (delta_R > 0.01f)
                door_R.transform.Translate(new Vector3(0.0f, 0.0f, -0.1f));
            if (delta_L > 0.01f)
                door_L.transform.Translate(new Vector3(0.0f, 0.0f, 0.1f));
        }

    }

 
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerCollider")
        {
          
            open = true;
            close = false;
            
        }
       
    }
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
       open = false;
       close = true;
    }
}

