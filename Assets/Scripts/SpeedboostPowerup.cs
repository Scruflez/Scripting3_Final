using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedboostPowerup : MonoBehaviour
{
    public float boostStrength;
    public float numBoosts;
    public bool useBoostCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (useBoostCounter)
        {
            if (numBoosts > 0)
            {
                if (other.tag == "Player")
                {
                    Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
                    carRigidbody.velocity = carRigidbody.velocity.normalized * boostStrength;
                    numBoosts--;
                }
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
                carRigidbody.velocity = carRigidbody.velocity.normalized * boostStrength;
                numBoosts--;
            }
        }
    }
}
