using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_49_2 : MonoBehaviour
{
    public float TimeToDestroy = 30f;
    public  NavMeshAgent agent;
    private GameObject Player;
    private GameObject SCP49;
    void Start()
    {
        Player = GameObject.Find("Capsule");
        StartCoroutine(Destroy());

    }

    void Update(){
        agent.SetDestination(Player.transform.position);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(TimeToDestroy);
        SCP49 = GameObject.Find("SCP-049");
        SCP_049 s49 = SCP49.GetComponent<SCP_049>();
        Destroy(gameObject);
        s49.DecreaseSCP_49_2();
    }
}
