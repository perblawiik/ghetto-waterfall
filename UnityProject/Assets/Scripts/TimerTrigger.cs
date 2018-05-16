using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour {

	private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            Timer t = other.gameObject.GetComponent(typeof(Timer)) as Timer;
            t.ToggleTimer();
        }
    }
}
