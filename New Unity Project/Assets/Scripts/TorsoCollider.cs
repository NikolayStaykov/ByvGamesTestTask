using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoCollider : MonoBehaviour
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
            Debug.Log("TorsoCollision");
            Destroy(collision.gameObject);
            controls.TakeDamage(2,collision.transform.position);
        }
        else if (collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Rocket")
        {
            Destroy(collision.gameObject);
            controls.DeathByExplosion();
        }
    }
}
