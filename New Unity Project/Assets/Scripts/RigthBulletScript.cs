using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthBulletScript : MonoBehaviour
{
    private Rigidbody2D BulletRigidBody;
    private Vector2 Force;
    private void Awake()
    {
        Force.y = 0;
        BulletRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Force.x = -100 * Time.deltaTime;
        BulletRigidBody.AddForce(Force,ForceMode2D.Force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
