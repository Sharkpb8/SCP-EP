using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_49_2 : MonoBehaviour
{
    public GameObject Player;
    public float TimeToDestroy = 30f;
    public  NavMeshAgent agent;
    void Start()
    {
        Destroy(gameObject,TimeToDestroy);
    }

    void Update(){
        agent.SetDestination(Player.transform.position);
    }
}
