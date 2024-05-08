using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Switch : MonoBehaviour
{
    public Material powered_color;
    public Material notpowered_color;
    public Material defaultcolor;
    public GameObject notpoweredcube;
    public GameObject poweredcube;
    public GameObject Player;
    public GameObject CubeStick;
    public GameObject CubeThing;
    public GameObject MainSwitch;
    private Animator mAnimator;
    private bool powered = false;
    Renderer cube1Render;
    Renderer cube2Render;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        cube1Render = notpoweredcube.GetComponent<Renderer>();
        cube1Render.material = notpowered_color;
        cube2Render = poweredcube.GetComponent<Renderer>();
        cube2Render.material = defaultcolor;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f && Input.GetKeyDown(KeyCode.F) && !powered){
            Main_Power_Switch mpw = MainSwitch.GetComponent<Main_Power_Switch>(); 
            mpw.power();
            powered = true;
            mAnimator.SetTrigger("Turn_On");
            cube1Render.material = defaultcolor;
            cube2Render.material = powered_color;
            CubeStick.tag = "Untagged";
            CubeThing.tag = "Untagged";
        }   
    }
}
