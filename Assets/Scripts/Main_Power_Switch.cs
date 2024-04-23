using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Power_Switch : MonoBehaviour
{
    public Material powered_color;
    private int generatorspowered = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(generatorspowered == 3){
            Renderer ColorRender = GetComponent<Renderer>();
            ColorRender.material = powered_color;
        }
    }

    public void power()
    {
        generatorspowered++;
    }
}
