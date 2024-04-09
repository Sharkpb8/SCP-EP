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
    public Transform Camera;
    public  NavMeshAgent agent;
    void Start()
    {
        
    }

    
    void Update()
    {
        ray = new Ray(Camera.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
        if (Physics.Raycast(ray, out hit, 300) && hit.collider.gameObject == face)
        {
            agent.SetDestination(Camera.position);
        }
    }
}
