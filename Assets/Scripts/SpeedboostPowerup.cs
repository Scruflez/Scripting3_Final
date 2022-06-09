using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedboostPowerup : MonoBehaviour
{
    public float boostStrength;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.tag == "Player")
        {
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
            carRigidbody.velocity = carRigidbody.velocity * boostStrength;
        }
    }
}
