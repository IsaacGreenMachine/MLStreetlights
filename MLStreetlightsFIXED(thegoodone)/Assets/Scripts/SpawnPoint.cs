using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    public string waypointType;
    public int lane;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
    }

    public GameObject GetSpawnCar(Vector3 pos)
    {
        return Instantiate(managerScript.car_prefabs[Random.Range(0, managerScript.car_prefabs.Count - 1)], pos, transform.rotation);
    }

    public void SpawnCar(List<GameObject> path, string direction)
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 1.5f);
        foreach (Collider c in hitColliders)
            if (c.gameObject.CompareTag("car")) return;
        GameObject car = GetSpawnCar(transform.position);
        Car carScript = car.GetComponent<Car>();
        carScript.speed = Random.Range(managerScript.carSpeedMin, managerScript.carSpeedMax);
        carScript.targetlist.AddRange(path);
        carScript.lane = lane;
        carScript.moving = true;
        carScript.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        if (waypointType == "start")
            Gizmos.color = Color.green;
        if (waypointType == "mid")
            Gizmos.color = Color.blue;
        if (waypointType == "end")
            Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (true)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

}