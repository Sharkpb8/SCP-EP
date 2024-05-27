using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infrared_Goggles : MonoBehaviour
{
     public GameObject Infrared;
    private bool turnedon = false;

    void Start()
    {
        Infrared.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(turnedon)
            {
                Infrared.SetActive(false);
                turnedon = false;
            }else{
                Infrared.SetActive(true);
                turnedon = true;
            }
        }
    }
}
