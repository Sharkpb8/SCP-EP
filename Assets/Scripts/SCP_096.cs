using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_096 : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject face;
    public Transform playerCamera;
    public  NavMeshAgent agent;
    public Transform []PatrolPoints;
    private bool faceseen;
    private int currentWaypoint = 0;

    void Update()
    {
        if(!faceseen){
            ray = new Ray(playerCamera.position, playerCamera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
            if (Physics.Raycast(ray, out hit, 300) && hit.collider.gameObject == face)
            {
                faceseen = true;
            }
            float distanceTopatrol = Vector3.Distance(PatrolPoints[currentWaypoint].position,transform.position);
            agent.SetDestination(PatrolPoints[currentWaypoint].position);
            if(distanceTopatrol<1f)
            {
                currentWaypoint++;
            if (currentWaypoint == PatrolPoints.Length)
            {
                currentWaypoint = 0;
            }   
            }     

        }else{
            agent.SetDestination(playerCamera.position);
        }
    }
}
