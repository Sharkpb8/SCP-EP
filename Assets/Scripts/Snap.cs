using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider colider)
    {
        if(colider.tag == "Player")
        {
            Destroy(player);
        }
        
    }
}
