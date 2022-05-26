using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    // Information about each individual axle
    public List<AxleInfo> axleInfos;
    // Maximum torque the motor can apply to wheel
    public float maxMotorTorque;
    // Maximum steer angle the wheel can have
    public float maxSteeringAngle; 

    public void FixedUpdate()
    {
        // Forwards/Backwards Input
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        // Steering
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        // Adjust each wheel
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    // Is this wheel attached to motor?
    public bool motor;
    // Does this wheel apply steer angle?
    public bool steering;
}
