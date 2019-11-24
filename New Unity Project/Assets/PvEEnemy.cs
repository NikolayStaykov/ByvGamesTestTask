using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvEEnemy : MonoBehaviour
{
    private int HP;
    void Start()
    {
        HP = 2;
    }
    public void TakeDamage(int Damage)
    {
        HP = HP - Damage;
        if(HP <= 0)
        {
            die();
        }
    }
    private void die()
    {
        HingeJoint2D[] joints = gameObject.GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (HingeJoint2D joint in joints)
        {
            joint.useLimits = false;
        }
        foreach (Rigidbody2D rigidbody in rigidbodies)
        {
            rigidbody.AddForce(new Vector2(30, 0), ForceMode2D.Force);
        }
    }
}
