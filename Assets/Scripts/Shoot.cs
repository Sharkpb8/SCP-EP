using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool shooting = true;
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        if(shooting && Input.GetMouseButton(0))
        {
            StartCoroutine(Fire());
        }
        
    }

    IEnumerator Fire()
    {
        shooting = false;
         Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if (Physics.Raycast(ray, out hit, 5))
            {
                
            }
        yield return new WaitForSeconds(0.086f);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        shooting = true;  
    }
}
