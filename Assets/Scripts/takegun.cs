using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takegun : MonoBehaviour
{
    public GameObject takgun;
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
        Weaponappear.Haveweapon = true;
        // Remove PowerUp 
        Destroy(takgun);
    }
}
