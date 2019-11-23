using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsCollider : MonoBehaviour
{
    private CharacterControls controls;
    private void Start()
    {
        controls = GetComponentInParent<CharacterControls>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Legs Collision Registered");
            Destroy(collision.gameObject);
            controls.TakeDamage(1,collision.transform.position);
        }
        else if(collision.gameObject.tag == "Ground")
        {
            GetComponentInParent<CharacterControls>().JumpReset();
        }
        else if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Rocket")
        {
            Destroy(collision.gameObject);
            controls.DeathByExplosion();
        }
    }
}
