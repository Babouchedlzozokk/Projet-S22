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
    [SerializeField] public Rigidbody Ont;

    private bool isShooting;
    private bool isGrappling;
    private Vector3 HookPoint;
    private Quaternion Rot;
    public bool visible;
    private void Start()
    {
        isGrappling = false;
        isShooting = false;
        visible = false;
        Ont = Player.GetComponent<Rigidbody>();
        Quaternion Rot = HandPos.rotation;
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
            if(Vector3.Distance(GrapplingHook.position,HookPoint) < 4)
            {
                HandPos.LookAt(HookPoint);
                Ont.AddForce(HandPos.transform.forward*1000, ForceMode.Force);
                HandPos.rotation = Rot;
            }
            if (Vector3.Distance(Player.transform.position, HookPoint - OffSet) < 4)
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