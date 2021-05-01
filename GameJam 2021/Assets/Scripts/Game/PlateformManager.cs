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
    private Vector3 _transformPosition;
    public Vector3 position;

    private void Start()
    {
        redPlateform = GameObject.FindGameObjectsWithTag("Plateform");
        MovePlatform();
        size = redPlateform.Length; 

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
        position = new Vector3(0, 0, 0);
        for (var i = 0; i < redPlateform.Length; i++)
        {
            redPlateform[i].transform.position += position;
        }
    }
}
