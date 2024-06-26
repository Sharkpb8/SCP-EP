using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Power_Switch : MonoBehaviour
{
    public Material powered_color;
    public GameObject[] Lights;
    public GameObject Player;
    public Animator mAnimator;
    public Animator DoorAnimator;
    private int generatorspowered = 0;
    private int lightindex = 0;
    private Renderer lightrenderer;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(generatorspowered == 3 && distance < 5f && Input.GetKeyDown(KeyCode.F))
        {
            mAnimator.SetTrigger("Turn On");
            DoorAnimator.SetTrigger("Open");
            gameObject.tag = "Untagged";
        }
    }

    public void power()
    {
        generatorspowered++;
        Debug.Log("lenght"+Lights.Length);
        lightrenderer = Lights[lightindex].GetComponent<Renderer>();
        lightindex++;
        lightrenderer.material = powered_color;
        if(generatorspowered==3)
        {
            gameObject.tag = "Interactable";
        }
    }
}
