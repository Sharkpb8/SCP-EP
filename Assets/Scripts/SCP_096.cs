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
    private Boolean faceseen;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!faceseen){
            ray = new Ray(playerCamera.position, playerCamera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
            if (Physics.Raycast(ray, out hit, 300) && hit.collider.gameObject == face)
            {
                faceseen = true;
            }
        }else{
            agent.SetDestination(playerCamera.position);
        }
        
    }
}
