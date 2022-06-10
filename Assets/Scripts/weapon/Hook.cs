using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform GrapplingHook;
    [SerializeField] private Transform HandPos;
    [SerializeField] private GameObject Player;    
    [SerializeField] public  LayerMask Hookable;
    [SerializeField] public  float maxDistance;
    [SerializeField] public float HookSpeed;
    [SerializeField] public Vector3 OffSet;

    private bool isShooting;
    private bool isGrappling;
    private Vector3 HookPoint;
    public bool visible;
    private void Start()
    {
        isGrappling = false;
        isShooting = false;
        visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
        }

        if (Input.GetKeyDown(INPUTS.tir_secondaire) && !visible)
        {
            ShootHook();
        }
        if (isGrappling)
        {
            GrapplingHook.position = Vector3.Lerp(GrapplingHook.position, HookPoint, HookSpeed * Time.deltaTime);
            if(Vector3.Distance(GrapplingHook.position,HookPoint) < 0.5)
            {
                Player.transform.position = Vector3.Lerp(Player.transform.position, HookPoint - OffSet  , HookSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(Player.transform.position, HookPoint - OffSet) < 0.5)
            {
                isGrappling = false ;
                isShooting = false ;
                GrapplingHook.SetParent(HandPos);
                GrapplingHook.position = HandPos.position;
                PlayerMovement.canDouble = true;
                GrapplingHook.rotation = HandPos.rotation;
                GrapplingHook.Rotate(90,0,0);
            }
        }
    }
        
    
    void ShootHook()
    {
        if (isShooting || isGrappling)
            return;
        isShooting = true;
        RaycastHit hit;
        Ray ray = new Ray(HandPos.position, HandPos.forward);
        if (Physics.Raycast(ray, out hit, maxDistance, Hookable))
        {
            SoundManagerScript.PlaySound("grappling");
            HookPoint = hit.point;
            isGrappling = true;
            GrapplingHook.parent = null;
            GrapplingHook.LookAt(HookPoint);
            
        }
        else
        {
            isShooting = false;
        }
    }
}