using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public GameObject Shield;
    private CharacterControls RightCharcter;
    private CharacterControls LeftCharcter;
    public void Awake()
    {
        CharacterControls[] characters = FindObjectsOfType<CharacterControls>();
        foreach (CharacterControls character in characters)
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
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<LeftBulletScript>())
            {
                Instantiate(Shield, LeftCharcter.gameObject.transform);
            }
            else
            {
                Instantiate(Shield, RightCharcter.gameObject.transform);
            }
            FindObjectOfType<PvPGameManager>().SpawnItemAllowed = true;
            Destroy(gameObject);
        }
    }
}
