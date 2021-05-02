using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    private Transform _target;
    public int destPoint;

    private void Start()
    {
        _target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            _target = waypoints[destPoint];
        }
    }
}
