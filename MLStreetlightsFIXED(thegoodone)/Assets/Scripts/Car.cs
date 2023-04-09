using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int speed;
    public string direction;
    public int lane;
    public int lanePriority;
    public GameObject manager;
    public manager managerScript;

    public Vector3 target;
    public GameObject targetObj;
    public List<GameObject> targetlist = new();

    public float carLength;
    public float carWidth;
    public float carHeight;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
        speed = Random.Range(managerScript.carSpeedMin, managerScript.carSpeedMax);

        Vector3 dims = GetComponent<BoxCollider>().bounds.size;
        carLength = dims.x;
        carHeight = dims.y;
        carWidth = dims.z;

        int randomPathIndex = Random.Range(0, managerScript.straightPaths.Count - 1);
        targetlist = new List<GameObject>(managerScript.straightPaths[randomPathIndex]);

        // Sets car position as first point in path
        transform.position = targetlist[0].transform.position;
        if (targetlist.Count != 0)
        {
            targetObj = GetNextTarget();
            target = targetObj.transform.position;
        }
    }

    RaycastHit createRaycastHit(Vector3 rayStart, float rayDistance, Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(rayStart, direction, out hit, rayDistance);
        Debug.DrawRay(transform.position + (direction * managerScript.HORIZONTAL_RAY_DISTANCE), direction * hit.distance, Color.yellow);
        return hit;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObj)
        {
            // Moves car
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Rotates car toward target
            transform.LookAt(target);
            transform.Rotate(new Vector3(0, -90, 0));

            if (AtPathPoint())
            {
                string targetType = targetObj.GetComponent<OverlapShow>().pointType;
                bool leftOrRight = (targetType.Contains("left") || targetType.Contains("right"));
                if (leftOrRight && direction != "Forward")
                {
                    // Determines new path name
                    targetlist = GetNewPath(targetObj.name);
                    targetObj = GetNextTarget(false);
                } else
                {
                    targetObj = GetNextTarget();
                }

                if (targetObj == null) Destroy(this);
                else target = targetObj.transform.position;
            }
        }

        //// Speed
        //transform.position += (managerScript.carSpeedModifier * speed * Time.deltaTime * transform.right);

        //// Front raycast
        //Vector3 frontRayStart = transform.position - (transform.right * managerScript.FRONT_RAY_START_DISTANCE);
        //RaycastHit frontRay = createRaycastHit(frontRayStart, managerScript.FRONT_RAY_DISTANCE, transform.right);

        //// Left back raycast
        //Vector3 leftRayStart = transform.position - (transform.forward * managerScript.HORIZONTAL_RAY_DISTANCE);
        //RaycastHit leftRay = createRaycastHit(leftRayStart, managerScript.FRONT_RAY_DISTANCE, transform.forward);

        //// Right back raycast
        //Vector3 rightRayStart = transform.position - ((-transform.forward) * managerScript.HORIZONTAL_RAY_DISTANCE);
        //RaycastHit rightRay = createRaycastHit(rightRayStart, managerScript.FRONT_RAY_DISTANCE, (-transform.forward));

        //// slower car is in front
        //if (frontRay.distance < managerScript.carDetectionDistance && frontRay.transform.gameObject.GetComponent<Car>().speed < speed)

        //// car is to the left
        //if (leftRay.distance < managerScript.carDetectionDistance)

        //// car is to the right
        //if (rightRay.distance < managerScript.carDetectionDistance)

        //// car needs to be in left lane and is not
        //if (direction == "left" && lane != 1)

        //// car needs to be in right lane and is not
        //if (direction == "right" && lane != 0)


    }

    /**
     * Merges a car into another lane. Assumes another lane's path are indexed similarly
     * (i.e., that currentPath[4] and newPath[4] are side-by-side points on
     * the same road)
     * Returns true if successful and false otherwise.
     */
    private bool mergeIntoLane(List<GameObject> newPath)
    {
        return true;
    }

    private bool AtPathPoint()
    {
        float distanceToPoint = Vector3.Distance(
            transform.position,
            target
        );// - (carLength / 2f); // carFront distance

        return distanceToPoint < managerScript.AT_PATH_POINT_RADIUS;
    }

    /**
     * Returns the next path GameObject, and a Vector3 with all NULL_VECTOR3_VAL values if no 
     * next path object.
     */
    private GameObject GetNextTarget(bool remove = true)
    {
        if (targetlist.Count >= 1 && remove) targetlist.RemoveAt(0);
        return targetlist.Count != 0 ? targetlist[0] : null;
    }

    private List<GameObject> GetNewPath(string objectName)
    {
        Debug.Log(objectName);
        switch (objectName)
        {
            case "oppzleft": return new List<GameObject>(managerScript.paths11);
            case "oppzright": return new List<GameObject>(managerScript.paths16);
            case "xleft": return new List<GameObject>(managerScript.paths13);
            case "xright": return new List<GameObject>(managerScript.paths10);
            case "zleft": return new List<GameObject>(managerScript.paths15);
            case "zright": return new List<GameObject>(managerScript.paths12);
            case "oppxleft": return new List<GameObject>(managerScript.paths9);
            case "oppxright": return new List<GameObject>(managerScript.paths14);
            default: return null;
        }

        // managerScript.GetType().GetField("path" + pathIndex).GetValue(this);
    }
}
