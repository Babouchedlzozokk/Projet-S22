using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PANELDIALOGUE : MonoBehaviour
{
    public GameObject panel;
    public GameObject healbar;
    public static bool test = false;
    private int count = 0;
    private bool test2 = false; 

    private void Start()
    {
        test2 = true;
    }

    private void Update()
    {
        if (test && test2)
        {
            healbar.SetActive(false);
            count++;
        }
        if (count == 1)
        {
            StartCoroutine(ReadingTime());
        }
    }

    IEnumerator ReadingTime()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(6);
        panel.SetActive(false);
        healbar.SetActive(true);
        Destroy(gameObject);
    }


}
