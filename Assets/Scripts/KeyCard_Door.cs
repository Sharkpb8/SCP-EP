using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class KeyCard_Door : MonoBehaviour
{
    public GameObject Button;
    public GameObject Door;
    public GameObject Frame;
    public GameObject Player;
    public int Level;
    public  NavMeshSurface agent;
    public Material[] levelMaterials;
    private int colorindex;
    private bool DoorEnabled = true;
    private Collider doorCollider;
    private Collider frameCollider;
    private Stats stats;
    void Start()
    {
        GameObject statsObject = GameObject.Find("Capsule");
        stats = statsObject.GetComponent<Stats>();
        colorindex=Level-1;
        Renderer buttonRenderer = Button.GetComponent<Renderer>();
        buttonRenderer.material  = levelMaterials[colorindex];
        doorCollider = Door.GetComponent<Collider>();
        frameCollider = Frame.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, Door.transform.position);
        if(distance < 5f && checkLevel()){
            if(Input.GetKeyDown(KeyCode.F)){
                ToggleDoor();
                agent.BuildNavMesh();
            }
        }
    }
    void ToggleDoor()
    {
        DoorEnabled = !DoorEnabled;
        doorCollider.enabled = DoorEnabled;
        frameCollider.enabled = DoorEnabled;
        
        Door.SetActive(DoorEnabled);
    }

    private bool checkLevel(){
        if(stats.Player_Level>=Level){
            return true;
        }else{
            return false;
        }
    }
}
