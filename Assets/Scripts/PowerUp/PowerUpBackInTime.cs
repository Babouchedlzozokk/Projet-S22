using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBackInTime : MonoBehaviour
{
    public static bool HaveBackInTime = false;
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
        // Apply effect to the player
        HaveBackInTime = true;
        // Remove PowerUp 
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
