using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMagager : MonoBehaviour
{
    public float speed;
    public Transform target;
    public bool isActive;
    public static BorderMagager instance;
    public Collider2D collider;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isActive)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World); 
        }

    }
    private void OnTriggerStay2D(Collider2D wallCollider)

    {

        if (wallCollider.CompareTag("Player"))
        {
            DieZone.instance.Die();
            if (DieZone.instance.isDie)
            {
                transform.position = new Vector3(-11.9f,0f,0f);
                isActive = false;
            }



        }
    }
}
