using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int speed;
    public string direction;
    public int lane;
    public int lanePriority;
    public GameObject manager;
    public manager managerScript;
    public bool carInFront;
    public Vector3 target;
    public GameObject targetObj;
    public List<GameObject> targetlist = new();
    public float carLength;
    public float carWidth;
    public float carHeight;
    public float distanceToWaypoint;

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
            target = targetObj.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
            transform.Rotate(new Vector3(0, -90, 0));
            distanceToWaypoint = Vector3.Distance(transform.position, targetObj.transform.position) - (carLength / 2f);
            if (distanceToWaypoint < 0.1f)
            {
                targetlist.RemoveAt(0);
                targetObj = null;
            }
        }
        else
        {
            if (targetlist.Count > 0)
                targetObj = targetlist[0];
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

}