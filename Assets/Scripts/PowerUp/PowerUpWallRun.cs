using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWallRun : MonoBehaviour
{
    public static bool HaveWallRun =false;
    public GameObject pickupEffect;
    public GameObject Panel;
    void Start()
    {
        
    }
    private void Update()
    {
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
        Panel.SetActive(true);
        yield return new WaitForSeconds(3);
        Panel.SetActive(false);
        Destroy(gameObject);
    }
}