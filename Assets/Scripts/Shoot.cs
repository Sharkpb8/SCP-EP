using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    private bool shooting = true;

    void Update()
    {
        if(shooting && Input.GetMouseButton(0))
        {
            StartCoroutine(SpawnBullet());
        }
        
    }

    IEnumerator SpawnBullet()
    {
        shooting = false;
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        yield return new WaitForSeconds(0.086f);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        shooting = true;  
    }
}
