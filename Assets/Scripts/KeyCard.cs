using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyCard : MonoBehaviour
{
    public GameObject Color_part;
    public int Level;
    public GameObject Player;
    public Material[] levelMaterials;
    private int colorindex;
    private Stats stats;
    void Start()
    {
        GameObject statsObject = GameObject.Find("Capsule");
        stats = statsObject.GetComponent<Stats>();
        Renderer ColorRender = Color_part.GetComponent<Renderer>();
        colorindex=Level-1;
        ColorRender.material  = levelMaterials[colorindex];
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f && Input.GetKeyDown(KeyCode.F)){
            stats.Player_Level = Level;
            Destroy(gameObject);
        }
    }

}
