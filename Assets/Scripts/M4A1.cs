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
    public Animator mAnimator;
    private bool Shooting = true;
    private bool Reloading = false;
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

        if(Shooting && Input.GetMouseButton(0) && Ammo > 0 && !Reloading)
        {
            StartCoroutine(Fire());
            Ammo -= 1;
            mag.text = Ammo+"/30";
        }

        if(Input.GetKeyDown(KeyCode.R) && !Reloading)
        {
            StartCoroutine(Reload());
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
                    DamageEnemies(hit.transform.gameObject);
                }
            }
        yield return new WaitForSeconds(0.086f);
        /* Debug.Log("Finished Coroutine at timestamp : " + Time.time); */
        Shooting = true;  
    }

    public void DamageEnemies(GameObject enemy)
    {
        enemy_stats es = enemy.GetComponent<enemy_stats>();
        es.takeDamage(damage);
    }

    IEnumerator Reload()
    {
        Reloading = true;
        mAnimator.SetTrigger("Reload");
        yield return new WaitForSeconds(1.9f);
        Ammo = 30;
        mag.text = Ammo+"/30";
        Reloading = false;
    }
}
