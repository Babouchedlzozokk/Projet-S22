using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Weaponappear : MonoBehaviour
{
    public GameObject weapon;
    public GameObject r;
    public GameObject r2;
    private PositionConstraint q;
    private PositionConstraint q2;
    private RotationConstraint q3;
    private ConstraintSource sed;
    private ConstraintSource sed2;
    private ConstraintSource sed3;
    public static bool Haveweapon = false;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        weapon.gameObject.SetActive(false);
        q = r.GetComponent<PositionConstraint>();
        sed = q.GetSource(0);
        q.RemoveSource(0);
        q2 = r2.GetComponent<PositionConstraint>();
        sed2 = q2.GetSource(0);
        q2.RemoveSource(0);
        q3 = r.GetComponent<RotationConstraint>();
        sed3 = q3.GetSource(0);
        q3.RemoveSource(0);

    }



    // Update is called once per frame
    void Update()
    { 
        if (Haveweapon)
        {
            weapon.gameObject.SetActive(true);
            q.AddSource(sed);
            q2.AddSource(sed2);
            q3.AddSource(sed3);
        }
    }

}
