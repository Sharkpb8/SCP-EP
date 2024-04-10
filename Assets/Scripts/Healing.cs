using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healing : MonoBehaviour
{
    public float heal;
    public Slider health_slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && HavePills())
        {
            Stats stats = GetComponent<Stats>();
            stats.Pills -= 1;
            stats.health += heal;
            if(stats.health > 100){
                stats.health = 100;
            }
            SetBar();
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

    public void SetBar(){
        Stats stats = GetComponent<Stats>();
        health_slider.value = stats.health;
    }
}
