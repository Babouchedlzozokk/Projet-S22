using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWallRun : MonoBehaviour
{
    public static bool HaveWallRun =false;
    public GameObject pickupEffect;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
        
    }
    void Pickup(Collider Player)
    {
        // Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect to the player
        HaveWallRun = true;
        // Remove PowerUp 
        Destroy(gameObject);
    }
}