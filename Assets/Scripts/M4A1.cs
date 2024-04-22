using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M4A1 : MonoBehaviour
{
    public GameObject bullethole;
    public int MagazineCap = 30;
    public TextMeshProUGUI mag;
    public float damage = 10f;
    private bool Shooting = true;
    [HideInInspector] public int Ammo;
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        Ammo = MagazineCap;
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

        if(Shooting && Input.GetMouseButton(0) && Ammo > 0)
        {
            StartCoroutine(Fire());
            Ammo -= 1;
            mag.text = Ammo+"/30";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Ammo = 30;
            mag.text = Ammo+"/30";
        }
        
    }

    IEnumerator Fire()
    {
        Shooting = false;
        /*  Debug.Log("Started Coroutine at timestamp : " + Time.time); */
        if (Physics.Raycast(ray, out hit, 500))
            {
                /* Instantiate(bullethole,hit.point + (hit.normal *0.1f),Quaternion.FromToRotation(Vector3.up,hit.normal)); */
                if(hit.transform.CompareTag("Enemy"))
                {
                    Debug.Log("E. ");
                    DamageEnemies(hit.transform.gameObject);
                    Debug.Log("B. ");
                }
                Debug.Log("D. ");
            }
        yield return new WaitForSeconds(0.086f);
        /* Debug.Log("Finished Coroutine at timestamp : " + Time.time); */
        Shooting = true;  
    }

    public void DamageEnemies(GameObject enemy)
    {
        Debug.Log("C. ");
        enemy_stats es = enemy.GetComponent<enemy_stats>();
        es.takeDamage(damage);
        Debug.Log("A. "+es.health);
    }
}
