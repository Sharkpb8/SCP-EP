using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class KeyCard_Door : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Button;
    public int Level;
    public Animator mAnimator;
    public Material[] levelMaterials;
    private int colorindex;
    private bool DoorOpen = true;
    private Stats stats;
    void Start()
    {
        stats = Player.GetComponent<Stats>();
        colorindex=Level-1;
        for(int i=0; i<Button.Length;i++)
        {
        Renderer buttonRenderer = Button[i].GetComponent<Renderer>();
        buttonRenderer.material  = levelMaterials[colorindex];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f && checkLevel() && Input.GetKeyDown(KeyCode.F)){
            DoorOpen = !DoorOpen;
            if(DoorOpen)
            {
                mAnimator.SetTrigger("TrClose");
            }else{
                mAnimator.SetTrigger("TrOpen");
            }
        }
    }

    private bool checkLevel(){
        if(stats.Player_Level>=Level)
        {
            return true;
        }else{
            return false;
        }
    }
}
