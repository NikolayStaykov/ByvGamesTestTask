using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControls : MonoBehaviour
{
    public bool Side;
    private int Health;
    public GameObject[] Hearts;
    public bool AttackCooldown;
    public GameObject Bullet;
    public GameObject Gun;
    private bool JumpAllowed;
    public ParticleSystem BloodSpray;
    private Vector3 BulletOffset;
    private Vector3 BloodSpraySpawn;
    private bool WeaponSwitch;
    public GameObject Bazooka;
    public GameObject Rocket;
    private Vector3 RocketOffset;
    void Start()
    {
        if(Side)
        {
            BulletOffset.x = 3.5f;
            BulletOffset.y = 1.9f;
            BloodSpraySpawn.x = 10.7f;
            RocketOffset.x = 3.62f;
            RocketOffset.y = -2.53f;
        }
        else
        {
            BulletOffset.x = 6.4f;
            BulletOffset.y = 2.24f;
            BloodSpraySpawn.x = -10.4f;
            RocketOffset.x = 0.49f;
            RocketOffset.y = -2.62f;
        }
        Health = 5;
        AttackCooldown = true;
        WeaponSwitch = false;
    }

    void Update()
    {
        Touch[] touches = Input.touches;
        foreach(Touch touch in touches)
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (touch.position.x < Screen.width / 2 && Side == false && JumpAllowed)
                {
                    if (gameObject.transform.position.y > -2.75f)
                    {
                        JumpAllowed = false;
                    }
                    gameObject.transform.Translate(0, 2, 0);
                }
                else if (touch.position.x > Screen.width / 2 && Side == true && JumpAllowed)
                {
                    if (gameObject.transform.position.y > -2.75f)
                    {
                        JumpAllowed = false;
                    }
                    gameObject.transform.Translate(0, 2, 0);
                }
            }
        }
    }

    public void TakeDamage(int DamageRecieved,Vector3 HitLocation)
    {
        int Damage = DamageRecieved;
        BloodSpraySpawn.y = HitLocation.y;
        BloodSpray.transform.position = BloodSpraySpawn;
        BloodSpray.Play();
        while(Health > 0 && Damage > 0)
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

    public void HealDamage(int HealPoints)
    {
        int ToHeal = HealPoints;
        while (Health < 5 && ToHeal > 0)
        {
            ToHeal--;
            Hearts[Health].SetActive(true);
            Health++;
        }
    }
    private void Die()
    {
        AttackCooldown = false;
        JumpAllowed = false;
        HingeJoint2D[] joints = gameObject.GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (HingeJoint2D joint in joints)
        {
            joint.useLimits = false;
        }
        if(Side)
        {
            foreach(Rigidbody2D rigidbody in rigidbodies)
            {
                rigidbody.AddForce(new Vector2(-30, 0), ForceMode2D.Force);
            }
        }
        else
        {
            foreach (Rigidbody2D rigidbody in rigidbodies)
            {
                rigidbody.AddForce(new Vector2(30, 0), ForceMode2D.Force);
            }
        }
        Invoke("EndGame", 1f);
    }

    public void DeathByExplosion()
    {
        AttackCooldown = false;
        JumpAllowed = false;
        HingeJoint2D[] joints = gameObject.GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody2D>();
        foreach (HingeJoint2D joint in joints)
        {
            Destroy(joint);
        }
        foreach (Rigidbody2D rigidbody in rigidbodies)
        {
            rigidbody.AddForce(new Vector2(Random.Range(-500,500), Random.Range(-500, 500)), ForceMode2D.Force);
        }
        Invoke("EndGame", 1f);
    }
    private void EndGame()
    {
        FindObjectOfType<PvPGameManager>().GameEnd();
    }

    public void FireProjectile()
    {
        if (WeaponSwitch)
        {
            if (AttackCooldown)
            {
                Vector3 PointToSpawn = Bazooka.transform.position + RocketOffset;
                Instantiate(Rocket, PointToSpawn, Rocket.transform.rotation, null);
                AttackCooldown = false;
                Invoke("ResetCooldown", 1.25f);
            }
        }
        else
        {
            if (AttackCooldown)
            {
                Vector3 PointToSpawn = Gun.transform.position + BulletOffset;
                Instantiate(Bullet, PointToSpawn, Bullet.transform.rotation, null);
                AttackCooldown = false;
                Invoke("ResetCooldown", 1.25f);
            }
        }
    }

    private void ResetCooldown()
    {
        AttackCooldown = true;
    }
    public void JumpReset()
    {
        JumpAllowed = true;
    }

    public void SwitchToBazooka()
    {
        WeaponSwitch = true;
        Gun.SetActive(false);
        Bazooka.SetActive(true);
        Invoke("SwitchToGun", 5);
    }
    public void SwitchToGun()
    {
        WeaponSwitch = false;
        Gun.SetActive(true);
        Bazooka.SetActive(false);
    }
}
