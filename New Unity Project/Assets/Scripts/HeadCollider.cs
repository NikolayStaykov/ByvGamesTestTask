using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour
{
    private CharacterControls controls;
    private void Start()
    {
        controls = GetComponentInParent<CharacterControls>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Head Collision Registered");
            Destroy(collision.gameObject);
            controls.TakeDamage(3,collision.transform.position);
        }
        else if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Rocket")
        {
            Destroy(collision.gameObject);
            controls.DeathByExplosion();
        }
    }
}
