using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMovement : MonoBehaviour
{
    public Transform[] targetPoints;
    int targetIndex;

    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        // Set the destination
        agent.SetDestination(targetPoints[targetIndex].position);

        // Check if the Agent has reached the destination
        if (Vector3.Distance(agent.destination, transform.position) < 1.05f)
        {
            targetIndex++;

            if (targetIndex >= targetPoints.Length)
            {
                targetIndex = 0;
            }
        }
    }
}
