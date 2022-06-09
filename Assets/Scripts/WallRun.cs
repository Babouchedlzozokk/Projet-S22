using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallRun : MonoBehaviour
{
    private Animator animator;
    private RaycastHit WallHitRight;
    private RaycastHit WallHitLeft;
    private Rigidbody rb;
    [SerializeField] public LayerMask WallMask;

    private bool WallLeft = false;
    private bool WallRight = false;

    [Header("camera")] 
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float WallRunfov;
    [SerializeField] private float WallRunfovTime;
    [SerializeField] private float Camtilit;
    [SerializeField] private float CamTiltTime;
    
    
    
    public  float tilt { get; private set; }
     
     
     
     
    [SerializeField]private float WallRunGravity;

    [SerializeField] private float WallJumpForce;
    [SerializeField] private Transform orientation;
    
   
    
    

    private void CheckWallLeft()
    {
        WallLeft = Physics.Raycast(transform.position, -orientation.right, out WallHitLeft, 1f,WallMask);
    }

    private void CheckWallRight()
    {
        WallRight = Physics.Raycast(transform.position, orientation.right, out WallHitRight, 1f, WallMask);
    }

    bool CanWallRun()
    {
        if (PlayerMovement.IsSprinting && !Physics.Raycast(transform.position, Vector3.down, 1.5f))
        {
            return true;
        }
        return false;

    }

    void StartWallRuning()
    {
        animator.SetBool("Wallrun", true);
        PlayerMovement.isGrounded = true;
        rb.useGravity = false;
        rb.AddForce(Vector3.down * WallRunGravity, ForceMode.Force);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, WallRunfov, WallRunfovTime * Time.deltaTime);

        if (WallLeft)
            tilt = Mathf.Lerp(tilt, -Camtilit, CamTiltTime * Time.deltaTime);
        else if (WallRight)
            tilt = Mathf.Lerp(tilt, Camtilit, CamTiltTime * Time.deltaTime);
            
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (WallLeft)
            {
                Vector3 WallRunJumpDirection = transform.up + WallHitLeft.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WallRunJumpDirection * WallJumpForce * 100 , ForceMode.Force);
            }

            if (WallRight)
            {
                Vector3 WallRunJumpDirection = transform.up + WallHitRight.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WallRunJumpDirection * WallJumpForce * 100 , ForceMode.Force);
            }
        }
    }

    void StopWallRuning()
    {
        animator.SetBool("Wallrun", false);
        rb.useGravity = true;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, WallRunfovTime * Time.deltaTime);
        tilt = Mathf.Lerp(tilt, 0, CamTiltTime * Time.deltaTime);
    }
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PowerUpWallRun.HaveWallRun)
        {
            CheckWallLeft();
            CheckWallRight();
            if (CanWallRun())
            {
                if (WallLeft)
                {
                    Debug.Log(" wall left ");
                    StartWallRuning();
                }

                else
                {
                    if (WallRight)
                    {
                        Debug.Log("Wall Right ");
                        StartWallRuning();
                    }
                    else
                    {
                        StopWallRuning();
                    }
                }
            }
            else
            {
                StopWallRuning();
            }
        }
    }
}
