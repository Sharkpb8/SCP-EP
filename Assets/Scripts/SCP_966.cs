using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SCP_966 : MonoBehaviour
{
    public GameObject Player;
    public  NavMeshAgent agent;
    public GameObject Infrared;
    private MeshRenderer meshRe;
    void Start()
    {
        meshRe = GetComponent<MeshRenderer>();
        meshRe.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        if(distanceToPlayer <10f)
        {
            agent.SetDestination(Player.transform.position);
        }

        if(Infrared.active == true)
        {
            meshRe.enabled = true;
        }else{
            meshRe.enabled = false;
        }
         
    }
}
