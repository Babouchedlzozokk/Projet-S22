using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public NavMeshAgent ennemy;
    public Transform player;
    public GameObject fusils;
    public LayerMask WhatIsGround, WhatIsPlayer;

    [Header("states")] 
    public float sightRange = 40; 
    public bool playerIsInSightRange;
    public bool playerIsInAttckRange;
    public bool playerTouch;
    public float health =1000 ;
    
    public bool HaveMoitierPv = false;


    [Header("attacking")]
    public GameObject cam;
    public static gun weapon;
    public ParticleSystem MuzzleFlash;
    public bool CanShoot = true;
    public bool CanCharge = true;
    public bool CanPunch = true;
    public bool IsCharging = false;
    private Rigidbody rb;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        weapon = new gun(10, 20, 0.2f , 1 , 30);
        player = GameObject.Find("Camera Position").transform;
        ennemy = GetComponent<NavMeshAgent>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerIsInAttckRange = Physics.CheckSphere(transform.position, weapon.range, WhatIsPlayer);

        if (HaveMoitierPv)
        {
            if (playerIsInSightRange && !playerIsInAttckRange)
            {
                ChasePlayer();
            }

            if (playerIsInSightRange && playerIsInAttckRange)
            {
                if (CanPunch)
                {
                    if (CanCharge)
                    {
                        StartCoroutine(Charge());
                    }
                    else
                    {
                        StartCoroutine(Punch());
                    }
                }
                ;
            }
            if (!playerIsInAttckRange && !playerIsInSightRange)
                ennemy.SetDestination(transform.position); 
        }
        else
        {
            if (playerIsInSightRange && !playerIsInAttckRange)
            {
                ChasePlayer();
            }

            if (playerIsInSightRange && playerIsInAttckRange)
            {
                if (CanCharge)
                {
                    StartCoroutine(Charge());
                }
                else
                {
                    AttackPlayer();
                }
            }
            if (!playerIsInAttckRange && !playerIsInSightRange)
                       ennemy.SetDestination(transform.position); 
        }
        
       

    }


    void ChasePlayer()
    {
        ennemy.SetDestination(player.position);
    }


    IEnumerator Punch()
    {
        
        yield return new WaitForSeconds(0.5f);
        
        RaycastHit hit ;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range) && CanPunch)
        {
            StartCoroutine(WaitForPunch());
            PlayerDamage p = hit.transform.GetComponent<PlayerDamage>();
            if (p != null)
                p.TakeDamage(weapon.damage);
            
        }
        
    }
    
    IEnumerator WaitForPunch()
    {
        CanPunch = false;
        yield return new WaitForSeconds(weapon.attackSpeed);
        CanPunch = true;

    }
    
    
    void AttackPlayer()
    { 
        ennemy.SetDestination(transform.position);
       fusils.transform.LookAt(player);
       StartCoroutine(Shoot());
    }
    

    IEnumerator Charge()
    {
        IsCharging = true;
        Vector3 playerPos = player.position;
        ennemy.speed = 100;
        ennemy.SetDestination(playerPos);
        ennemy.speed = 10;
        yield return new WaitForSeconds(5);
        StartCoroutine(WaitForCharge());
        
    }

   

    IEnumerator WaitForCharge ()
    {
        Debug.Log("Mincraft");
        CanCharge = false;
        IsCharging = false;
        yield return new WaitForSeconds(10 );
        CanCharge = true;
        
    }
    
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);
        Vector3 Random_xy = new Vector3(Random.Range(-weapon.spread, weapon.spread), Random.Range(-weapon.spread, weapon.spread),0);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward+Random_xy, out hit, weapon.range) && CanShoot)
        {
            MuzzleFlash.Play();
            StartCoroutine(WaitForShoot());
            PlayerDamage p = hit.transform.GetComponent<PlayerDamage>();
            if (p != null)
                p.TakeDamage(weapon.damage);
        }
        
    }
    IEnumerator WaitForShoot()
    {
        CanShoot = false;
        yield return new WaitForSeconds(1);
        CanShoot = true;

    }
    
    
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 500 && !HaveMoitierPv)
        {
            HaveMoitierPv = true;
            weapon = new gun(50, 15, 0, 1, 1);
            Destroy(fusils);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    
    
}