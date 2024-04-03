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
        if (Input.GetKeyDown(KeyCode.E)){
            IncreaseLevel();
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            DecreaseLevel();
        }
        Level.text = Player_Level.ToString();
    }
    public void IncreaseLevel(){
        Player_Level++;
        if(Player_Level>5){
            Player_Level = 5;
        }
    }

    public void DecreaseLevel(){
        Player_Level--;
        if(Player_Level<0){
            Player_Level = 0;
        }
    }

}
