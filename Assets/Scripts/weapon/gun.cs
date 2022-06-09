using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class gun
{
    public string name ;
    public float damage;
    public float range;
    public float spread ;
    public float attackSpeed;
    public float chargeur;

    public float Damage => damage;
    public float Range => range;
    public float Spread => spread;

    public float AttackSpeed => attackSpeed;
    public float Chargeur => chargeur;
    public gun(float damage, float range, float spread , float attackSpeed , float chargeur)
    {
        this.damage = damage;
        this.range = range;
        this.spread = spread;
        this.attackSpeed = attackSpeed;
        this.chargeur = chargeur;
    }

}