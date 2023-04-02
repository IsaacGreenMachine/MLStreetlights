using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int speed;
    public string direction;
    public int lane;
    public GameObject manager;
    public manager managerScript;
    public bool carInFront;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
        speed = Random.Range(managerScript.carSpeedMin, managerScript.carSpeedMax);
        direction = managerScript.directions[Random.Range(0, managerScript.directions.Count)];

    }

    RaycastHit createRaycastHit(Vector3 rayStart, int rayDistance)
    {
        RaycastHit hit;
        Physics.Raycast(rayStart, Vector3.right, out hit, rayDistance);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        return hit;
    }

    // Update is called once per frame
    void Update()
    {
        // Speed
        transform.position += (managerScript.carSpeedModifier * speed * Time.deltaTime * transform.right);

        // Front raycast
        Vector3 frontRayStart = transform.position + (transform.right * managerScript.FRONT_RAY_START_DISTANCE);
        RaycastHit frontRay = createRaycastHit(frontRayStart, managerScript.FRONT_RAY_DISTANCE);

        // Left back raycast
        //Vector3 leftRayStart = transform.position + (transform.right * managerScript.FRONT_RAY_START_DISTANCE);
        //RaycastHit leftRay = createRaycastHit(leftRayStart, managerScript.FRONT_RAY_DISTANCE);

        //// Right back raycast
        //Vector3 rightRayStart = transform.position + (transform.right * managerScript.FRONT_RAY_START_DISTANCE);
        //RaycastHit rightRay = createRaycastHit(rightRayStart, managerScript.FRONT_RAY_DISTANCE);
    }
}
