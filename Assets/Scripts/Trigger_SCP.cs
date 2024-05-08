using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SCP : MonoBehaviour
{
    public GameObject SCP;
    void Start()
    {
        SCP.SetActive(false);
    }

    private void OnTriggerEnter(Collider colider)
    {
        if(colider.tag == "Player")
        {
            SCP.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
