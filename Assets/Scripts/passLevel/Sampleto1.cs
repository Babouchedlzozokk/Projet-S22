using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Sampleto1 : MonoBehaviour
{
    Scene newscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamage.maxHealth = PlayerDamage.Health;
            PowerUpDash.HaveDash = false;
            PowerUpDoubleJump.canDoubleJump = false;
            PowerUpWallRun.HaveWallRun = false;
            PowerUpBackInTime.HaveBackInTime = false;
            Hook.HaveHook = false;
            Weaponappear.Haveweapon = false;
            
            Pickup(other);
        }

    }
    void Pickup(Collider player)
    {
        SceneManager.LoadScene("LEVEL 1S");    
    }
}