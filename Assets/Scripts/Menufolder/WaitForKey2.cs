using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaitForKey2 : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HealthBar;

    private void Start()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
    }

    private void Update()
    {
        HealthBar.SetActive(false);
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode) && kcode != KeyCode.Escape)
            {
                Time.timeScale = 1f;
                Panel.SetActive(false);
                HealthBar.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
