using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;

public class KeyCard_Door : MonoBehaviour
{
    public GameObject Button;
    public GameObject Door;
    public int Level;
    public Material[] levelMaterials;
    private int colorindex;
    void Start()
    {
        colorindex=Level-1;
        Renderer buttonRenderer = Button.GetComponent<Renderer>();
        buttonRenderer.material  = levelMaterials[colorindex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
