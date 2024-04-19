using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public GameObject player;
    private Stats stats;

    void Start()
    {
        stats = player.GetComponent<Stats>();
    }
    private void OnTriggerEnter(Collider colider)
    {
        if(colider.tag == "Player")
        {
            stats.health = 0;
        }
        
    }
}