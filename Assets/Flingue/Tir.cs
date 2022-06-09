using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public Transform GunTip;
    private RaycastHit Touch;
    Rigidbody rb;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(GunTip.position,GunTip.forward *100);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Physics.BoxCast(GunTip.position, GunTip.lossyScale / 2, GunTip.forward, out Touch
            , GunTip.rotation, 10f) && (Input.GetMouseButtonDown(1)))
        {
            
            if (Touch.collider.GetComponent<Rigidbody>() == null)
            {

            }
            else
            {
                rb = Touch.collider.GetComponent<Rigidbody>();
                rb.AddForce(GunTip.forward * 1000);
            }

        }
        

    }
    
}
