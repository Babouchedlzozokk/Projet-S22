using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level9to10 : MonoBehaviour
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
        SceneManager.LoadScene("LEVEL 10S");    
    }
}
