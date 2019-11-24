using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float HP;
    public void Awake()
    {
        HP = 5;
    }

    void Update()
    {
        if(HP > 0)
        {
            HP = HP - 1 * Time.deltaTime;
        }
        else
        {
            FindObjectOfType<PvPGameManager>().SpawnItemAllowed = true;
            Destroy(gameObject);
        }

    }
}
