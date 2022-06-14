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
    public Animator animator;   
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

    public GameObject Empty;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        weapon = new gun(37, 20, 0.1f , 1 , 30);
        player = GameObject.Find("Player").transform;
        ennemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

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
                animator.SetBool("Walk", false);
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
            {
                animator.SetBool("Walk", true);
                ennemy.SetDestination(transform.position);
            }
        }
        else
        {
            if (playerIsInSightRange && !playerIsInAttckRange)
            {
                ChasePlayer();
            }

            if (playerIsInSightRange && playerIsInAttckRange)
            {
                animator.SetBool("Walk", false);
                if (CanCharge)
                {
                    if (!soundplaying)
                    {
                        StartCoroutine(SoundCharge());
                        SoundManagerScript.PlaySound("scream");

                    }
                    StartCoroutine(Charge());
                }
                else
                {
                    AttackPlayer();
                }
            }
            if (!playerIsInAttckRange && !playerIsInSightRange)
            {
                ennemy.SetDestination(transform.position);
                animator.SetBool("Walk", true);
            }

        }
        
       

    }
    void ChasePlayer()
    {
        animator.SetBool("Walk", true);
        ennemy.SetDestination(player.position);
    }


    IEnumerator Punch()
    {
        cam.transform.LookAt(player);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Punch", true);
        RaycastHit hit ;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range) && CanPunch)
        {
            StartCoroutine(WaitForPunch());
            PlayerDamage p = hit.transform.GetComponent<PlayerDamage>();
            if (p != null)
                p.TakeDamage(weapon.damage);
            
        }
        animator.SetBool("Punch", false);
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
        transform.LookAt(player);
       cam.transform.LookAt(player);
       StartCoroutine(Shoot());
    }

    IEnumerator Charge()
    {
        IsCharging = true;
        animator.SetBool("Charge", true);
        Vector3 playerPos = player.position;
        ennemy.speed = 30;
        ennemy.SetDestination(playerPos);
        yield return new WaitForSeconds(5);
        StartCoroutine(WaitForCharge());
    }

    private bool soundplaying = false;
   IEnumerator SoundCharge()
    {
        soundplaying = true;
        yield return new WaitForSeconds(10);
        soundplaying = false;
    }

   IEnumerator WaitForCharge ()
   {
       Debug.Log("Mincraft");
       ennemy.speed = 10;
        animator.SetBool("Charge", false);
        CanCharge = false;
       IsCharging = false;
       yield return new WaitForSeconds(10 );
       CanCharge = true;
        
   }
    
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(weapon.attackSpeed);
        Vector3 Random_xy = new Vector3(Random.Range(-weapon.spread, weapon.spread), Random.Range(-weapon.spread, weapon.spread),0);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward+Random_xy, out hit, weapon.range) && CanShoot)
        {
            MuzzleFlash.Play();
            SoundManagerScript.PlaySound("gunshot");
            StartCoroutine(WaitForShoot());
            PlayerDamage p = hit.transform.GetComponent<PlayerDamage>();
            if (p != null)
                p.TakeDamage(weapon.damage);
        }
        
    }
    IEnumerator WaitForShoot()
    {
        CanShoot = false;
        yield return new WaitForSeconds(weapon.attackSpeed);
        CanShoot = true;

    }
    
    
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 250 && !HaveMoitierPv)
        {
            HaveMoitierPv = true;
            weapon = new gun(50, 15, 0, 1, 1);
            Destroy(fusils);
        }
        if (health <= 0)
        {
            Empty.SetActive(true);
            Destroy(gameObject);
        }
    }
    
    
    
    
}