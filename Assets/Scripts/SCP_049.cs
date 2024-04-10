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
    [HideInInspector] public int body_spawnpoints = 0;
    private GameObject []bodies;
    private Transform target;
    void Start()
    {
        bodies = GameObject.FindGameObjectsWithTag("Body");
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestBody();
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        float distanceToBody = Vector3.Distance(target.position,transform.position);
        float distanceTopatrol = Vector3.Distance(PatrolPoints[currentWaypoint].position,transform.position);
        if(distanceToPlayer<10f){
            agent.SetDestination(Player.transform.position);

        }else{
            if(distanceToBody<distanceTopatrol){
                agent.SetDestination(target.position);
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

    private void FindNearestBody()
    {
        float minDistance = Mathf.Infinity;
        foreach (GameObject b in bodies)
        {
            float distance = Vector3.Distance(transform.position, b.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = b.transform;
            }
        }
    }
}
