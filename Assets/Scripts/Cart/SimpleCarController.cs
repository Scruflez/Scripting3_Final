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

    private Vector3 still;
}

public class SimpleCarController : MonoBehaviour
{
    [Header("Player Inputs")]
    // Acceleration Input Name;
    public string playerAcceleration;
    // Steering Input Name
    public string playerSteering;

    [Header("Axles")]
    // Information about each individual axle
    public List<AxleInfo> axleInfos;

    [Header("Car Control Values")]
    // Maximum torque the motor can apply to wheel
    public float maxMotorTorque;
    // Maximum steer angle the wheel can have
    public float maxSteeringAngle;
    // Car Gravity
    public Vector3 carGravity;

    [Header("References")]
    // Car RidgidBody
    public Rigidbody carRigidbody;
    // Reference to the Constant Force
    public ConstantForce customGravity;
    // Center of Gravity
    public GameObject centerOfMass;


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
        // Adjust Center of Mass
        carRigidbody.centerOfMass = centerOfMass.transform.localPosition;
        
        // Apply Downward Force
        customGravity.relativeForce = carGravity * carRigidbody.mass;

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

        //checkBreaks();
        //Prints Speed
        Debug.Log(motor);
        //Debug.Log(carRigidbody.velocity.magnitude);
        //Debug.Log(Input.GetAxis(playerAcceleration));
    }

    // WIP
    /*
    public void checkBreaks()
    {
        if (carRigidbody.velocity.magnitude > 0 && Input.GetAxis(playerAcceleration) < 0)
        {
            carRigidbody.velocity = carRigidbody.velocity / 1.05f;
        }
    }
    */
}