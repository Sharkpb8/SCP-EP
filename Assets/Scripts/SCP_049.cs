using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class SCP_049 : MonoBehaviour
{
    public Transform []PatrolPoints;
    /* public Transform SpawnPoints; */
    public GameObject Player;
    public GameObject SCP_49_2;
    public  NavMeshAgent agent;
    private int currentWaypoint = 0;
    private int SCP_049_2_count = 0;
    private bool spawning = true;
    private float spotingrange = 20f;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        float distanceTopatrol = Vector3.Distance(PatrolPoints[currentWaypoint].position,transform.position);
        if(distanceToPlayer<spotingrange){
            agent.SetDestination(Player.transform.position);
            setspotingrange(true);
            if(SCP_049_2_count<5)
            {
                if(spawning)
                {
                    StartCoroutine(Spawn_SCP_49_2());
                    SCP_049_2_count++;
                }
            }
            /* Instantiate(SCP_49_2,SpawnPoints); */

        }else{
            setspotingrange(false);
            agent.SetDestination(PatrolPoints[currentWaypoint].position);
            if(distanceTopatrol<1f)
            {
                currentWaypoint++;
                if (currentWaypoint == PatrolPoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
        }
        
    }

    Vector3 RandomPosition(Vector3 origin, float distance)
    {
        Vector3 randDirection = Random.insideUnitSphere * distance;
        randDirection += origin;
        /* NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, distance,0);
        return navHit.position; */
        return randDirection;
    }

    IEnumerator Spawn_SCP_49_2()
    {
        spawning = false;
        Vector3 randomPoint = RandomPosition(transform.position, 5f);
        Instantiate(SCP_49_2, randomPoint, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        spawning = true;
    }

    public void DecreaseSCP_49_2()
    {
        SCP_049_2_count -=1;
    }

    private void setspotingrange(bool chasing)
    {
        if(chasing)
        {
            spotingrange = 40f; 
        }else
        {
            spotingrange = 20f;
        }

    }
}
