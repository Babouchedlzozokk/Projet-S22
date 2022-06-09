using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class INPUTSHOOT : MonoBehaviour
{
    public GameObject detectInput;
    public GameObject CtrlSettings;
    private void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                INPUTS.tir_principal = kcode;
                detectInput.SetActive(false);
                CtrlSettings.SetActive(true);
            }
        }
    }
}
