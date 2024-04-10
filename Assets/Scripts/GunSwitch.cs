using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSwitch : MonoBehaviour
{
    public GameObject Slot1;
    public GameObject Slot1_bh;
    public GameObject Slot2;
    public GameObject Slot2_bh;
    public TextMeshProUGUI mag;
    private int m4A1ScriptCapacity;
    private int uziCapacity;
    
    void Start()
    {
        M4A1 m4A1Script = Slot1_bh.GetComponent<M4A1>();
        m4A1ScriptCapacity = m4A1Script.MagazineCap;

        Uzi uziScript = Slot1_bh.GetComponent<Uzi>();
        uziCapacity = uziScript.MagazineCap;

        Slot1.SetActive(true);
        Slot2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Slot2.SetActive(false);
            Slot1.SetActive(true);
            mag.text = m4A1ScriptCapacity+"/30";
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slot1.SetActive(false);
            Slot2.SetActive(true);
            mag.text = uziCapacity+"/40";
        }
    }
}
