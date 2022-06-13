using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHook : MonoBehaviour
{
    private bool test = false;


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
        Hook.HaveHook = true;
        Destroy(gameObject);
    }
}

