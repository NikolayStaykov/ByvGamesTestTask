using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void Awake()
    {
        Invoke("Expire", 5);
    }
    private void Expire()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Rocket")
        {
            Destroy(collision.gameObject);
        }
    }
}
