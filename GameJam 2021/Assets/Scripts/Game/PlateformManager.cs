using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject[] redPlateform;

    public float redPlateformPosX;
    public int size;
    public float speed;
    public Transform target;
    public bool moveRedPlatform;
    public int plateID;
    public static PlateformManager instance;
    public GameObject platObj;
    public float platposy;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        plateID = 0;
        moveRedPlatform = false;
        redPlateform = GameObject.FindGameObjectsWithTag("Plateform");
       MovePlatform();

    }

    private void Update()
    {
        
        if (!moveRedPlatform) return;
        Vector3 dir = target.position - redPlateform[plateID].transform.position;
        redPlateform[plateID].transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
            
        if (Vector3.Distance(redPlateform[plateID].transform.position, target.position) < 0.2f)
        {
            plateID++; 
            
            
        }
        if (plateID == redPlateform.Length)
        {
            moveRedPlatform = false;
            Destroy(GameObject.FindGameObjectWithTag("PlateformTargetPoint"));
                        
            plateID = 0;
        }

    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void MovePlatform()
    {

        for (var i = 0; i < redPlateform.Length; i++)
        {
            
            platposy = redPlateform[plateID].transform.position.y;
            GameObject PlateformTarget = GameObject.CreatePrimitive(PrimitiveType.Cube);
            PlateformTarget.tag = "PlateformTargetPoint";
            PlateformTarget.GetComponent<MeshRenderer>().enabled = false;
            PlateformTarget.transform.position = redPlateform[plateID].transform.position;
            PlateformTarget.name = "[AUTOGENERATE] plateform travel point";
            target = PlateformTarget.transform;
            moveRedPlatform = true;
        }
         
         
    }
    
}
