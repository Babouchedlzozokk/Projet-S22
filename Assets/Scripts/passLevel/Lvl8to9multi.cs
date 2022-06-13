using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lvl8to9multi : MonoBehaviour
{// Start is called before the first frame update
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
        SceneManager.LoadScene("LEVEL 9");
    }
}
