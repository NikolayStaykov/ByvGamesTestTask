using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvECharacterControls : MonoBehaviour
{
    public GameObject Axe;
    public Vector3 AxeSpawnPoint;
    private Vector3 SwipeStart;
    private Vector3 SwipeEnd;
    private float MinimumSwipeDistance;
    public GameObject PropAxe;
    private bool AttackAllowed;
    private void Start()
    {
        MinimumSwipeDistance = Screen.width / 5;
        AxeSpawnPoint = PropAxe.transform.position;
        AttackAllowed = true;
    }
    void Update()
    {
        if (Input.touchCount == 1 && AttackAllowed)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                SwipeStart = touch.position;
                SwipeEnd = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                SwipeEnd = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                SwipeEnd = touch.position;
            }
        }
        if(Vector3.Distance(SwipeStart,SwipeEnd) > MinimumSwipeDistance)
        {
            ThrowAxe();
        }

    }

    private void ThrowAxe()
    {
        PropAxe.SetActive(false);
        AttackAllowed = false;
        GameObject SpawnedAxe = Instantiate(Axe, AxeSpawnPoint, Axe.transform.rotation, null);
        Vector2 Force;
        Force.x = SwipeEnd.x - SwipeStart.x;
        Force.y = SwipeEnd.y - SwipeStart.y;
        SpawnedAxe.GetComponent<Rigidbody2D>().AddForce(Force);
    }

    private void AttackCoolDown()
    {
        PropAxe.SetActive(true);
        AttackAllowed = true;
    }
}
