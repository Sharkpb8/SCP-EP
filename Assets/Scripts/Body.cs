using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject SCP_049;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == SCP_049)
        {
            SCP_049 S49 = SCP_049.GetComponent<SCP_049>();
            S49.body_spawnpoints +=1;
            Destroy(gameObject);
        }
    }
}
