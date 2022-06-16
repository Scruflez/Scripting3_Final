using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            player.transform.position = player.previousCheckpoint.transform.position;
            player.transform.rotation = player.previousCheckpoint.transform.rotation;
            // Angular rotation
        }
    }
}
