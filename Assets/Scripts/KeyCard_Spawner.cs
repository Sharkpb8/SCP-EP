using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard_Spawner : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject Keycard;
    private int chance;
    private int roll;
    private bool spawned = false;
    void Start()
    {
        for(int i = 0;i<spawns.Length;i++)
        {
            chance = (i+1)*2+2;
            roll = Random.Range(1,chance);
            if(roll == 1 && !spawned)
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 90, 90);
                Instantiate(Keycard, spawns[i].transform.position, spawnRotation);
                spawned = true;
            }
        }

        if(!spawned)
        {
            Quaternion spawnRotation = Quaternion.Euler(0, 90, 90);
            Instantiate(Keycard, spawns[0].transform.position, spawnRotation);
        }
    }
}
