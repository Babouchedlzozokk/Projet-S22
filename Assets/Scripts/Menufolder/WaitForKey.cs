using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaitForKey : MonoBehaviour
{

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject ScriptDialogue;
    public GameObject CanvasHealth;
    public int value = 0;

    private void Start()
    {
        Panel1.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        CanvasHealth.SetActive(false);
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode) && kcode != KeyCode.Escape)
            {
                value++;
                if (value == 1)
                {
                    Panel1.SetActive(false);
                    Panel2.SetActive(true);
                }
                else if (value == 2)
                {
                    Panel2.SetActive(false);
                    Panel3.SetActive(true);
                }
                else
                {
                    Panel3.SetActive(false);
                    Time.timeScale = 1f;
                    CanvasHealth.SetActive(true);
                    ScriptDialogue.SetActive(false);
                }
            }
        }
    }
}
