using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoCollider : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            GetComponentInParent<CharacterControls>().TakeDamage(2);
        }
    }
}
