using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public GameObject bullethole;
    public int MagazineCap = 30;
    public TextMeshProUGUI mag;
    private bool shooting = true;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        if(shooting && Input.GetMouseButton(0) && MagazineCap > 0)
        {
            StartCoroutine(Fire());
            MagazineCap -= 1;
            mag.text = MagazineCap+"/30";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            MagazineCap = 30;
            mag.text = MagazineCap+"/30";
        }
        
    }

    IEnumerator Fire()
    {
        shooting = false;
         Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if (Physics.Raycast(ray, out hit, 500))
            {
                Instantiate(bullethole,hit.point + (hit.normal *0.1f),Quaternion.FromToRotation(Vector3.up,hit.normal));
            }
        yield return new WaitForSeconds(0.086f);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        shooting = true;  
    }
}
