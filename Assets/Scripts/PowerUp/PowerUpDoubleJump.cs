using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleJump : MonoBehaviour
{
    public GameObject pickupEffect;
    public static bool canDoubleJump = false;
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
        canDoubleJump = true;
        // Remove PowerUp 
        Destroy(gameObject);
    }
}
