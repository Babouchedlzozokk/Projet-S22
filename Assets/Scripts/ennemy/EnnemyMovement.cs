using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnnemyMovement : MonoBehaviour
{
    public GameObject fusil;
    public NavMeshAgent ennemy;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    [Header("states")] 
    public float sightRange = 40;
    public bool playerIsInSightRange;
    public bool playerIsInAttckRange;
    public float heath =100 ;
    
    
    [Header("attacking")]
    public GameObject cam;
    public static gun weapon;
    public ParticleSystem MuzzleFlash;
    public bool CanShoot = true;
    public bool CanDash = true;
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        weapon = new gun(25, 20, 0.2f , 0.75f , 30);

        player = GameObject.Find("Camera Position").transform;
        ennemy = GetComponent<NavMeshAgent>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerIsInAttckRange = Physics.CheckSphere(transform.position, weapon.range, WhatIsPlayer);

        if (playerIsInSightRange && !playerIsInAttckRange)
            ChasePlayer();
        if (playerIsInSightRange && playerIsInAttckRange)
        {
            if (CanDash)
            { 
                int WichMove = Random.Range(0, 100);
                if (WichMove >= 75)
                {
                    Debug.Log("Dash");
                    Dash();
                }
                else 
                { 
                    AttackPlayer();
                }
                StartCoroutine(WaitForDash());
            }
            else 
            { 
                AttackPlayer();
            }    
        }
        if (!playerIsInAttckRange && !playerIsInSightRange)
            ennemy.SetDestination(transform.position);
            
    }

    
    void Dash ()
    {
        int x1;
        int y1;
        Vector3 vect;
        int x = Random.Range(0,1);
        if (x == 0)
        {
            x1 = Random.Range(1, 5);
            x1 *= 20;
             
        }
        else
        {
            x1 = Random.Range(1, 5);
            x1 *= -20;
            

        }
        y1 = Random.Range(-1, 1);
        rb.AddForce(ennemy.transform.right*x1+ennemy.transform.forward*y1,ForceMode.Impulse);
        
    }

    IEnumerator WaitForDash()
    {
        CanDash = false;
        yield return new WaitForSeconds(5);
        CanDash = true;

    }

    void ChasePlayer()
    {
        ennemy.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        ennemy.SetDestination(transform.position);
        cam.transform.LookAt(player);
        fusil.transform.LookAt(player);
        StartCoroutine(Shoot());

    }
    
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(weapon.attackSpeed);
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
        yield return new WaitForSeconds(weapon.attackSpeed);
        CanShoot = true;

    }

    public void TakeDamage(float damage)
    {
        heath -= damage;
        Debug.Log("Enemy toucher ");
        if (heath <= 0)
        {
            Destroy(gameObject);

        }
    }
}