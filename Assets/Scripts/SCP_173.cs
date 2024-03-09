using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_173 : MonoBehaviour
{
   public Transform playerCamera;
    public LayerMask obstructionLayer; // Layer mask to detect obstructions between SCP-173 and the player
    private NavMeshAgent agent;
    private bool isPlayerLooking;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckPlayerLineOfSight();
        ControlMovement();
    }

    bool IsInView()
    {
        Vector3 screenPoint = playerCamera.GetComponent<Camera>().WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        // Check for obstructions
        RaycastHit hit;
        Vector3 direction = transform.position - playerCamera.position;
        if (Physics.Raycast(playerCamera.position, direction, out hit, Mathf.Infinity, obstructionLayer))
        {
            // If direct view is obstructed, SCP-173 is not in view
            return hit.transform == transform && onScreen;
        }

        // If not obstructed and within screen bounds, SCP-173 is in view
        return onScreen;
    }

    void CheckPlayerLineOfSight()
    {
        isPlayerLooking = IsInView();
    }

    void ControlMovement()
    {
        if (!isPlayerLooking)
        {
            // If player is not looking, SCP-173 can move
            agent.isStopped = false;
            agent.SetDestination(playerCamera.position);
        }
        else
        {
            // If player is looking, SCP-173 stops
            agent.isStopped = true;
        }
    }
}
