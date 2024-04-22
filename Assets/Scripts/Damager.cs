using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private bool isPlayerInside = false;
    private const float damagePerSecond = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isPlayerInside)
        {
            // Calculate the amount of damage to deal based on the damage per second and the time since the last frame
            float damage = damagePerSecond * Time.deltaTime;

            // Deal the damage to the player
            other.GetComponent<Stats>().takeDamage(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}