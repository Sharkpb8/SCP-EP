using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCP_500 : MonoBehaviour
{
    public TextMeshProUGUI PillsCount;
    public int Ammount;
    public GameObject player;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 5f && Input.GetKeyDown(KeyCode.F)){
            Stats stats = player.GetComponent<Stats>();
            stats.Pills =stats.Pills+Ammount;
            PillsCount.text = "Pills lef: "+stats.Pills;
            Destroy(gameObject);
        }
    }
}
