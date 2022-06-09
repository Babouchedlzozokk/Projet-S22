using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuGame : MonoBehaviour
{
    private bool visible;
    public GameObject panel;
    public GameObject canvas;
    public GameObject buttonHolder;

    void Start()
    {
        visible = false;
        panel.SetActive(visible);
        buttonHolder.SetActive(visible);
        canvas.SetActive(!visible);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            visible = !visible;
            panel.SetActive(visible);
            buttonHolder.SetActive(visible);
            canvas.SetActive(!visible);
        }
    }
}
