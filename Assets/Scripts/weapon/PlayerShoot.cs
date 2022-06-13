using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour
{
    
    [SerializeField] private Camera cam;

    [SerializeField] private LayerMask mask;
    
    public ParticleSystem muzzleFlash;
    public GameObject DamageEffects;
    public GameObject HitEffects;
    public bool canShoot = true;
    public float BalleRestante;

    public gun weapon;
    public Text ammo;



    // Start is called before the first frame update
    private void Awake()
    {
        weapon =  new gun(15 ,20 ,0 , 0.2f , 20);
        
}

    public bool visible;

    void Start()
    {
        visible = false;
        BalleRestante = weapon.chargeur;
        ammo.text = BalleRestante + "/20";

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
        }

        if (!visible && Weaponappear.Haveweapon )
        {
            if (Input.GetKeyDown(INPUTS.reload))
                StartCoroutine(Reload());
            if (canShoot)
            {
                if (BalleRestante <= 0)
                    StartCoroutine(Reload());
                else if ( Input.GetKey(INPUTS.tir_principal))
                {
                    SoundManagerScript.PlaySound("gunshot");
                    Shoot();
                    ammo.text = BalleRestante + "/20";
                    muzzleFlash.Play();
                   
                }
            }
        }
            

    }

    private void Shoot()
    {
        
        RaycastHit hit;
        BalleRestante--;
        ammo.text = BalleRestante + "/20";
        Vector3 Random_xy = new Vector3(Random.Range(-weapon.spread, weapon.spread), Random.Range(-weapon.spread, weapon.spread),0);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward+Random_xy, out hit, weapon.range))
        {
            EnnemyMovement e = hit.transform.GetComponent<EnnemyMovement>();
            EnnemyQuiBougePas g = hit.transform.GetComponent<EnnemyQuiBougePas>();
            Boss B = hit.transform.GetComponent<Boss>();
            if (e != null)
            {
                DamageEffect(hit.point,hit.normal);
                e.TakeDamage(weapon.damage);
                
            }
            else if (g != null)
            {
                DamageEffect(hit.point,hit.normal);
                g.TakeDamage(weapon.damage);
            }
            else if (B != null)
            {
                DamageEffect(hit.point,hit.normal);
                B.TakeDamage(weapon.damage);
            }
            else
            {
                 HitEffect(hit.point,hit.normal);
            }    
           
            
            
        }
        StartCoroutine(waitForShoot());
    }

    void HitEffect(Vector3 pos, Vector3 normal)
    {
        GameObject particle =  Instantiate(HitEffects, pos, Quaternion.LookRotation(normal)) ;
        
        Destroy(particle, 1f);
        
    }
    
    void DamageEffect(Vector3 pos, Vector3 normal)
    {
        GameObject particle =  Instantiate(DamageEffects, pos, Quaternion.LookRotation(normal)) ;
        
        Destroy(particle, 10f);
        
    }

    private IEnumerator waitForShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(weapon.attackSpeed);
        canShoot = true;
    }

    IEnumerator Reload()
    {
        canShoot = false;
        SoundManagerScript.PlaySound("reload");
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
        BalleRestante = weapon.chargeur;
        ammo.text = BalleRestante + "/20";
    }
    

}