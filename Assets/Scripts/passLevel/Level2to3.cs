using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2to3 : MonoBehaviour
{
    Scene newscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamage.maxHealth = PlayerDamage.Health;
            Pickup(other);
        }

    }
    void Pickup(Collider player)
    {
        SceneManager.LoadScene("LEVEL 3S");    
    }
}
