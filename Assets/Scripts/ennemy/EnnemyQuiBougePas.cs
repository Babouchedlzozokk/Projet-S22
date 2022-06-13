using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyQuiBougePas : MonoBehaviour
{
    
    public GameObject fusil;
    public NavMeshAgent ennemy;
    public Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;

    [Header("states")] 
    public float sightRange = 30;
    public bool playerIsInSightRange;
    public bool playerIsInAttckRange;
    
    
    [Header("attacking")]
    private bool AlreadyAttacked;
    public GameObject cam;
    public static gun weapon;
    public ParticleSystem MuzzleFlash;
    public bool CanShoot = true;
    public float heath =200 ;
    
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        weapon = new gun(37, 40, 0 , 0.8f , 50);

        player = GameObject.Find("Camera Position").transform;
        ennemy = GetComponent<NavMeshAgent>();
        ennemy.SetDestination(transform.position);

    }
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        playerIsInAttckRange = Physics.CheckSphere(transform.position, weapon.range, WhatIsPlayer);
        
        if ( playerIsInAttckRange)
        {
            AttackPlayer();
        }
      
            
    }


  

    void AttackPlayer()
    {
        ennemy.SetDestination(transform.position);
        transform.LookAt(player);
        fusil.transform.LookAt(player);
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
        if (heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
