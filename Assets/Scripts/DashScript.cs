using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [Header("Dash")]
    public float DashForce = 100;
    bool isDashing= false;
    Rigidbody rb;
    private bool visible;

    [SerializeField] Transform orientation;

    [SerializeField] KeyCode DashKey = KeyCode.LeftControl;
    void Start()
    {
        visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
        }

        if (Input.GetKeyDown(DashKey) == true && isDashing == false && PowerUpDash.HaveDash == true && !visible)
        {         
            StartCoroutine(WaitDashing());        
        }
        
    }
    void StartDash()
    {
        rb.AddForce(orientation.forward * DashForce , ForceMode.Impulse);
        rb.AddForce(-Physics.gravity);
        isDashing = true;
    }
    void StopDash()
    {
        isDashing = false;
    }
    IEnumerator WaitDashing()
    {
        StartDash();
        yield return new WaitForSeconds(1f);
        StopDash();
    }
}
