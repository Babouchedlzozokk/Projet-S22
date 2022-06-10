using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBackInTime : MonoBehaviour
{
    public GameObject pickupEffect;
    public static bool HaveBackInTime = false;
    void Start()
    {
        
    }
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
        HaveBackInTime = true;
        // Remove PowerUp 
        Destroy(gameObject);
    }
}
