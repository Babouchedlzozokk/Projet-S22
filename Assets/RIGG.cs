using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIGG : MonoBehaviour
{
    
    public GameObject az;
    public GameObject aze;
    // Update is called once per frame
    void Update()
    {
        az.transform.position = aze.transform.position;
    }
}
