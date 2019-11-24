using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvEBodyCollider : MonoBehaviour
{
    private PvEEnemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<PvEEnemy>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            Destroy(collision.gameObject);
            enemy.TakeDamage(1);
        }
    }
}
