using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_049 : MonoBehaviour
{
    public Transform []PatrolPoints;
    public GameObject Player;
    public  NavMeshAgent agent;
    private int currentWaypoint = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        /* float distanceToWaypoint = Vector3.Distance(transform.position, PatrolPoints[currentWaypoint].position); */
        if(distanceToPlayer<10f){
            agent.SetDestination(Player.transform.position);

        }else{
            agent.SetDestination(PatrolPoints[currentWaypoint].position);
            Debug.Log(PatrolPoints.Length);
        }
        
    }
}
