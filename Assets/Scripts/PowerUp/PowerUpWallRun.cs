using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWallRun : MonoBehaviour
{
    public static bool HaveWallRun =false;
    public GameObject pickupEffect;
    public GameObject Panel;
    public GameObject Healthbar;
    private bool test = false;
    private void Update()
    {
        if (test)
            Healthbar.SetActive(false);
    }
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
        StartCoroutine(ReadingTime());
    }

    IEnumerator ReadingTime()
    {
        test = true;
        Panel.SetActive(true);
        yield return new WaitForSeconds(6);
        Panel.SetActive(false);
        Healthbar.SetActive(true); 
        Destroy(gameObject);
    }
}