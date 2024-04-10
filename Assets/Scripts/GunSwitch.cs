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
            mag.text = getM4A1_ammo()+"/30";
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slot1.SetActive(false);
            Slot2.SetActive(true);
            mag.text = getuzi_ammo()+"/40";
        }
    }

    public int getM4A1_ammo()
    {
        M4A1 m4A1Script = Slot1_bh.GetComponent<M4A1>();
        m4A1ScriptCapacity = m4A1Script.Ammo;
        return m4A1ScriptCapacity;
    }

    public int getuzi_ammo()
    {
        Uzi uziScript = Slot2_bh.GetComponent<Uzi>();
        uziCapacity = uziScript.Ammo;
        return uziCapacity;
    }
}
