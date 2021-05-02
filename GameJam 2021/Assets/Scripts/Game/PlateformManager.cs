using Game;
using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject[] redPlateform;
public Vector3[] startposX;
    public float redPlateformPosX;
    public float speed;
    public Transform target;
    public bool moveRedPlatform;
    public int plateID;
    public static PlateformManager instance;
    public GameObject platObj;
    public Vector3 platpos;
    
    public bool isTheFirstTime;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        plateID = 0;
        moveRedPlatform = false;
        redPlateform = GameObject.FindGameObjectsWithTag("Plateform");
        isTheFirstTime = true;


    }

    private void Update()
    {
        if (!moveRedPlatform) return;
        Vector3 dir = target.position - redPlateform[plateID].transform.position;
        redPlateform[plateID].transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
        
        if (Vector3.Distance(redPlateform[plateID].transform.position, target.position) < 0.2f)
        {
            if (plateID == redPlateform.Length - 1)
            {
                moveRedPlatform = false;
                plateID = 0;
                isTheFirstTime = false;
                return;
            }

            plateID++;
            MovePlatform();
            
        }

    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void MovePlatform()
    {
      //  Vector3 StartPos = Vector3.zero;
      //       StartPos.y = redPlateform[plateID].transform.position.y;
      //       StartPos.x = redPlateform[plateID].transform.position.x;
     //
      //       startposX[plateID] = StartPos;

        redPlateformPosX = Random.Range(-2, 2);
        platObj = redPlateform[plateID];
        platpos = platObj.transform.position;
        var targetPosition = target.position;
        targetPosition.x = platpos.x += redPlateformPosX;
        targetPosition.y = platpos.y;
        target.position = targetPosition;
        
       

        moveRedPlatform = true;


    }
    
}
