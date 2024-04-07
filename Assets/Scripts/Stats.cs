using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public int Player_Level = 0;
    public TextMeshProUGUI Level;

    void Update(){
        Level.text = Player_Level.ToString();
    }

}
