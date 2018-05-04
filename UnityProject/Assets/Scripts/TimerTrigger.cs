using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Player").SendMessage("StartTimer");
    }
}
