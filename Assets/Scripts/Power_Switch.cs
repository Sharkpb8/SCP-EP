using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Switch : MonoBehaviour
{
    public Material powered_color;
    public Material notpowered_color;
    public GameObject Player;
    private Animator mAnimator;
    private bool powered = false;
    Renderer ColorRender;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        ColorRender = GetComponent<Renderer>();
        ColorRender.material = notpowered_color;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f && Input.GetKeyDown(KeyCode.F) && !powered){
            GameObject statsObject = GameObject.Find("Power");
            Main_Power_Switch mpw = statsObject.GetComponent<Main_Power_Switch>(); 
            mpw.power();
            powered = true;
            mAnimator.SetTrigger("Turn_On");
            ColorRender.material = powered_color;
        }   
    }
}
