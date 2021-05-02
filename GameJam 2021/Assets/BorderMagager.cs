using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMagager : MonoBehaviour
{
    public float speed;
    public Transform target;
    public bool isActive;
    private void Update()
    {
        if (isActive)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World); 
        }
       
    }
}
