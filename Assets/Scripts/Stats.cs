using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int Player_Level = 0;
    public int Pills = 0;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI PillsCount;

    void Start()
    {
        PillsCount.text = "Pills lef: "+Pills;
    }

    void Update(){
        Level.text = Player_Level.ToString();
    }

}
