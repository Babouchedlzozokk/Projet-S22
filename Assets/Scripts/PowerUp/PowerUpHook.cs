 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHook : MonoBehaviour
{
   
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
        // Apply effect to the player
        Hook.havehook= true;
        // Remove PowerUp 
        Destroy(gameObject);
    }
}
