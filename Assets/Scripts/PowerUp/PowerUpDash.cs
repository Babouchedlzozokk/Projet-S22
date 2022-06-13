using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUpDash : MonoBehaviour
{
    public static bool HaveDash = false;
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
        test = true;
        Panel.SetActive(true);
        yield return new WaitForSeconds(6);
        Panel.SetActive(false);
        Healthbar.SetActive(true);
        Destroy(gameObject);
    }
}
