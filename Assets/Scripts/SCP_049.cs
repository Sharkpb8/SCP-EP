using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_049 : MonoBehaviour
{
    public Transform []PatrolPoints;
    public Transform []SpawnPoints;
    public GameObject Player;
    public GameObject SCP_49_2;
    public  NavMeshAgent agent;
    private int currentWaypoint = 0;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        float distanceTopatrol = Vector3.Distance(PatrolPoints[currentWaypoint].position,transform.position);
        if(distanceToPlayer<10f){
            agent.SetDestination(Player.transform.position);

        }else{
            agent.SetDestination(PatrolPoints[currentWaypoint].position);
            currentWaypoint++;
            if (currentWaypoint == PatrolPoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        
    }
}
