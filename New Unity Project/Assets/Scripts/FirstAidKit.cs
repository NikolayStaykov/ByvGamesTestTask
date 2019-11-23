using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private CharacterControls RightCharcter;
    private CharacterControls LeftCharcter;
    private int HP;
    public void Awake()
    {
        HP = 5;
        CharacterControls[] characters = FindObjectsOfType<CharacterControls>();
        foreach(CharacterControls character in characters)
        {
            if (character.Side)
            {
                RightCharcter = character;
            }
            else
            {
                LeftCharcter = character;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(HP >= 1)
        {
            HP--;
        }
        else
        {
            if (collision.gameObject.GetComponent<LeftBulletScript>())
            {
                LeftCharcter.HealDamage(3);
            }
            else
            {
                RightCharcter.HealDamage(3);
            }
            Destroy(gameObject);
        }
    }
}
