using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uzi : MonoBehaviour
{
    public GameObject bullethole;
    public int MagazineCap = 40;
    public TextMeshProUGUI mag;
    private bool Shooting = true;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        if(Shooting && Input.GetMouseButton(0) && MagazineCap > 0)
        {
            StartCoroutine(Fire());
            MagazineCap -= 1;
            mag.text = MagazineCap+"/40";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            MagazineCap = 40;
            mag.text = MagazineCap+"/40";
        }
        
    }

    IEnumerator Fire()
    {
        Shooting = false;
         Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if (Physics.Raycast(ray, out hit, 500))
            {
                Instantiate(bullethole,hit.point + (hit.normal *0.1f),Quaternion.FromToRotation(Vector3.up,hit.normal));
            }
        yield return new WaitForSeconds(0.010f);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Shooting = true;  
    }
}
