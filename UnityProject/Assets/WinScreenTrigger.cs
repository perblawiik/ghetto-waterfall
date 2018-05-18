using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            GameObject.Find("InGameUI").SendMessage("WinningScreen");
        }
    }
}
