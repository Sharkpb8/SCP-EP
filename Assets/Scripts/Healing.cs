using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEditor.Experimental.GraphView;

public class Healing : MonoBehaviour
{
    public float heal;
    public Slider health_slider;
    public TextMeshProUGUI PillsCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && HavePills() && playerhealth())
        {
            Stats stats = GetComponent<Stats>();
            stats.Pills -= 1;
            stats.health += heal;
            if(stats.health > 100){
                stats.health = 100;
            }
            PillsCount.text = "Pills lef: "+stats.Pills;
        }
    }

    public bool HavePills(){
        Stats stats = GetComponent<Stats>();
        if(stats.Pills>0){
            return true;
        }else{
            return false;
        }
    }

    public bool playerhealth(){
        Stats stats = GetComponent<Stats>();
        if(stats.health<100){
            return true;
        }else{
            return false;
        }
    }
}
