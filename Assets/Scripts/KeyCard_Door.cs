using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;

public class KeyCard_Door : MonoBehaviour
{
    public GameObject Button;
    public GameObject Door;
    public GameObject Frame;
    public GameObject Player;
    public int Level;
    public Material[] levelMaterials;
    private int colorindex;
    private bool DoorEnabled = true;
    private Collider doorCollider;
    private Collider frameCollider;
    void Start()
    {
        colorindex=Level-1;
        Renderer buttonRenderer = Button.GetComponent<Renderer>();
        buttonRenderer.material  = levelMaterials[colorindex];
        doorCollider = Door.GetComponent<Collider>();
        frameCollider = Frame.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Check if the player is close to the door
            float distance = Vector3.Distance(Player.transform.position, Door.transform.position);
            if (distance < 5f) // Adjust the distance as needed
            {
                // Toggle the state of the door
                ToggleDoor();
            }
        }
    }
    void ToggleDoor()
    {
        DoorEnabled = !DoorEnabled;
        doorCollider.enabled = DoorEnabled;
        frameCollider.enabled = DoorEnabled;
        
        // Enable or disable the door based on its current state
        Door.SetActive(DoorEnabled);
    }
}
