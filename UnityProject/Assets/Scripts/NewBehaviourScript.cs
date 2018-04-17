using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {



    public float MotorForce, SteerForce, BreakForce; public WheelCollider wheelfrontleft, wheelfrontrightSphere, wheelbackleft, wheelbackright; void Start() { }
    void Update() { float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * SteerForce;
        wheelbackleft.motorTorque = v;
        wheelbackright.motorTorque = v;
        wheelfrontleft.motorTorque = h;
        wheelfrontrightSphere.motorTorque = h;
        if (Input.GetKey(KeyCode.Space)) {
            wheelbackleft.brakeTorque = BreakForce;
            wheelbackright.brakeTorque = BreakForce;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }
        if (Input.GetAxis("Vertical") == 0)
        { wheelbackleft.brakeTorque = BreakForce;
            wheelbackright.brakeTorque = BreakForce;
        }
        else {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }
    }
}
