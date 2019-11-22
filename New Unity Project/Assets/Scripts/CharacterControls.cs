using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    private bool Side;
    private int Health;
    public GameObject[] Hearts;
    void Start()
    {
        if(this.GetComponentInParent<Transform>().position.x < Screen.width / 2)
        {
            Side = false;
        }
        else
        {
            Side = true;
        }
        Health = 5;
    }

    void Update()
    {
        Touch touch = Input.GetTouch(0); 
        if(touch.position.x < Screen.width / 2 && Side == false)
        {
            gameObject.transform.Translate(0, 0.5f, 0);
        }
        else if (touch.position.x > Screen.width / 2 && Side == true)
        {
            gameObject.transform.Translate(0, 0.5f, 0);
        }
    }

    public void TakeDamage(int DamageRecieved)
    {
        int Damage = DamageRecieved;
        while(Health > 0 || Damage != 0)
        {
            Health--;
            Hearts[Health].SetActive(false);
            Damage--;
        }
        if(Health == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        FindObjectOfType<PvPGameManager>().GameEnd();
    }
}
