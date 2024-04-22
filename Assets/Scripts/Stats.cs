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
    public float health = 100;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI PillsCount;
    public Slider health_slider;
    private float barvalue;

    void Start()
    {
        PillsCount.text = "Pills lef: "+Pills;
        health_slider.value = health;
    }

    void Update(){
        Level.text = Player_Level.ToString();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        SetBar();
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    private void SetBar(){
        Stats stats = GetComponent<Stats>();
        if(stats.health<40)
        {
            barvalue = stats.health/2;
            health_slider.value = barvalue;
        }
        else
        {
            health_slider.value = stats.health;
        }
    }

}
