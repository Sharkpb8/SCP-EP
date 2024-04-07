using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public GameObject Color_part;
    public int Level;
    public Material[] levelMaterials;
    private int colorindex;
    void Start()
    {
        Renderer ColorRender = Color_part.GetComponent<Renderer>();
        colorindex=Level-1;
        ColorRender.material  = levelMaterials[colorindex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
