using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDash : MonoBehaviour
{
    public static bool HaveDash = false;
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

    }
    void Pickup(Collider player)
    {
        // Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect to the player
        HaveDash = true;
        // Remove PowerUp 
        Destroy(gameObject);
    }
}
