using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject[] redPlateform;

    public float redPlateformPosX;
    public int size;
    public float speed;
    public Transform target;

    private void Start()
    {
        redPlateform = GameObject.FindGameObjectsWithTag("Plateform");
        MovePlatform();
        size = redPlateform.Length;
        target = (redPlateformPosX,0,0);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {

        for (var i = 0; i < redPlateform.Length; i++)
        {
            
            Vector3 dir = target.position - redPlateform[i].transform.position;
            redPlateform[i].transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
        }
    }
}
