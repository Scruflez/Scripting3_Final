using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class SimpleCarController : MonoBehaviour
{
    // Acceleration Input Name;
    public string playerAcceleration;
    // Steering Input Name
    public string playerSteering;
    // Information about each individual axle
    public List<AxleInfo> axleInfos;
    // Maximum torque the motor can apply to wheel
    public float maxMotorTorque;
    // Maximum steer angle the wheel can have
    public float maxSteeringAngle;
    // Car RidgidBody
    public Rigidbody carRigidbody;
    // Car Gravity
    public Vector3 carGravity;


    // Finds the corresponding visual wheel
    // Correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        // Movement forward with input
        float motor = maxMotorTorque * Input.GetAxis(playerAcceleration);
        // Sideways steering with side inputs
        float steering = maxSteeringAngle * Input.GetAxis(playerSteering);

        // Adjusts the wheels to move the car
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
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void Update()
    {
        carRigidbody.AddRelativeForce(carGravity*Time.deltaTime, ForceMode.Acceleration);
    }
}