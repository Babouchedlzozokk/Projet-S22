using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpDash : MonoBehaviour
{
    public static bool HaveDash = false;
    public GameObject pickupEffect;
    public GameObject Panel;
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
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Apply effect to the player
        HaveDash = true;
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
