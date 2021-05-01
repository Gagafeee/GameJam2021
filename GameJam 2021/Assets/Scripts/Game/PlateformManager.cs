using UnityEngine;

public class PlateformManager : MonoBehaviour
{
    public GameObject[] redPlateform;

    public float redPlateformPosX;
    public float speed;
    public Transform target;
    public bool moveRedPlatform;
    public int plateID;
    public static PlateformManager instance;
    public GameObject platObj;
    public Vector3 platpos;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
        plateID = 0;
        moveRedPlatform = false;
        redPlateform = GameObject.FindGameObjectsWithTag("Plateform");

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
                return;
            }

            plateID++;
            MovePlatform();
            
        }

    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void MovePlatform()
    {

        redPlateformPosX = Random.Range(-5, 5);
        platObj = redPlateform[plateID];
        platpos = platObj.transform.position;
        var targetPosition = target.position;
        targetPosition.x = platpos.x += redPlateformPosX;
        targetPosition.y = platpos.y;
        target.position = targetPosition;
        
        //platpos = redPlateform[plateID].transform.position.y;
        //GameObject PlateformTarget = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //PlateformTarget.tag = "PlateformTargetPoint";
        //PlateformTarget.GetComponent<MeshRenderer>().enabled = false;
        //PlateformTarget.transform.position = redPlateform[plateID].transform.position;
        //PlateformTarget.name = "[AUTOGENERATE] plateform travel point";
        //target = PlateformTarget.transform;
        moveRedPlatform = true;


    }
    
}
