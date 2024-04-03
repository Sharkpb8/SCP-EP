using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_173 : MonoBehaviour
{
   public Transform playerCamera;
    public LayerMask obstructionLayer; // Layer mask to detect obstructions between SCP-173 and the player
    public  NavMeshAgent agent;
    private bool isPlayerLooking;

    void Start()
    {
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

        RaycastHit hit;
        Vector3 direction = transform.position - playerCamera.position;
        if (Physics.Raycast(playerCamera.position, direction, out hit, Mathf.Infinity, obstructionLayer))
        {
            return hit.transform == transform && onScreen;
        }

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
            agent.isStopped = false;
            agent.SetDestination(playerCamera.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }
}