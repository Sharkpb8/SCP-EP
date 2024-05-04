using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Power_Switch : MonoBehaviour
{
    public Material powered_color;
    public GameObject[] Lights;
    public GameObject Switch;
    private int generatorspowered = 0;
    private int lightindex = 0;
    private Renderer lightrenderer;
    void Start()
    {
        Debug.Log("lenght start"+Lights.Length);
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
        Debug.Log("1."+lightindex);
        Debug.Log("lenght"+Lights.Length);
        lightrenderer = Lights[lightindex].GetComponent<Renderer>();
        Debug.Log("2."+lightindex);
        lightindex++;
        Debug.Log("3."+lightindex);
        lightrenderer.material = powered_color;
    }
}
