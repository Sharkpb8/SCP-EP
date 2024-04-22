using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_stats : MonoBehaviour
{
    public float health = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            die();
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
