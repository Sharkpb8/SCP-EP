using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SCP_500_Spawner : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject SCP500;
    private int chance;
    private int roll;
    private int pillsleft = 50;
    private GameObject spawedSCP500;
    void Start()
    {
        for(int i = 0;i<spawns.Length;i++)
        {
            chance = pillsleft-spawns.Length+i;
            if(i == spawns.Length-1)
            {
                roll = pillsleft;
            }else
            {
                roll = Random.Range(1,chance);
            }
            pillsleft = pillsleft-roll;
            Quaternion spawnRotation = Quaternion.Euler(270, 0, 0);
            spawedSCP500 = Instantiate(SCP500, spawns[i].transform.position,spawnRotation);
            SCP_500 s500 = spawedSCP500.GetComponent<SCP_500>();
            s500.Ammount = roll;
        }
    }
}
