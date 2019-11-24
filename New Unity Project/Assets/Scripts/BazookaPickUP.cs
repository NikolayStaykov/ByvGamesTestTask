using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaPickUP : MonoBehaviour
{
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
        if (collision.gameObject.tag != "Ground")
        {
            if (collision.gameObject.GetComponent<LeftBulletScript>())
            {
                LeftCharcter.SwitchToBazooka();
            }
            else
            {
                RightCharcter.SwitchToBazooka();
            }
            FindObjectOfType<PvPGameManager>().SpawnItemAllowed = true;
            Destroy(gameObject);
        }
    }
}
