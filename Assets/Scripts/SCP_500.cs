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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Stats stats = player.GetComponent<Stats>();
            stats.Pills =stats.Pills+Ammount;
            PillsCount.text = "Pills lef: "+stats.Pills;
            Destroy(gameObject);
        }
    }
}
