using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public List<GameObject> car_prefabs = new();
    public List<GameObject> spawn_points = new();
    public List<string> directions = new() { "Left", "Forward", "Right" };
    public List<string> lightStates = new() { "Green", "Yellow", "Red", "GreenLeftFull", "GreenLeft", "YellowLeftFull", "YellowLeft" };
    public int carSpeedMin;
    public int carSpeedMax;
    public int yellowDelayTime;
    [Range(0, 1)]
    public float carSpeedModifier;
    public float FRONT_RAY_START_DISTANCE;
    public float HORIZONTAL_RAY_DISTANCE;
    public float FRONT_RAY_DISTANCE;
    public float carDetectionDistance;
    public enum waypointTypes
    {
        start,
        mid,
        stop,
    }

    public List<GameObject> allWaypoints = new();
    public List<GameObject> spawnPoints = new();

    public List<GameObject> SRR = new();
    public List<GameObject> SRS = new();
    public List<GameObject> SLL = new();
    public List<GameObject> SLS = new();
    public List<GameObject> ERR = new();
    public List<GameObject> ERS = new();
    public List<GameObject> ELL = new();
    public List<GameObject> ELS = new();
    public List<GameObject> NRR = new();
    public List<GameObject> NRS = new();
    public List<GameObject> NLL = new();
    public List<GameObject> NLS = new();
    public List<GameObject> WRR = new();
    public List<GameObject> WRS = new();
    public List<GameObject> WLL = new();
    public List<GameObject> WLS = new();
    public Dictionary<List<GameObject>, string> allPaths = new();
    public List<List<GameObject>> allPathNames = new();
    public float AT_PATH_POINT_RADIUS = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform waypointtrans in GameObject.Find("AllWaypoints").transform)
        {
            SpawnPoint scrpt = waypointtrans.gameObject.GetComponent<SpawnPoint>();
            allWaypoints.Add(waypointtrans.gameObject);
            if (scrpt.waypointType == "start")
                spawnPoints.Add(waypointtrans.gameObject);
                     }
        foreach (GameObject car in Resources.LoadAll("Prefabs"))
            car_prefabs.Add(car);
        allPaths = new Dictionary<List<GameObject>, string>{{ SRR, "R" }, { SRS, "S" }, { SLL, "L" }, { SLS, "S"}, { ERR, "S"}, { ERS, "S" }, { ELL, "L"}, { ELS, "S" }, { NRR, "R" }, { NRS, "S" }, { NLL, "L" }, { NLS, "S" }, { WRR, "R" }, { WRS, "S" }, { WLL, "L" }, { WLS, "S" } };
        allPathNames = new List<List<GameObject>>(allPaths.Keys);
        GameObject.Find("StoplightArray").GetComponent<StopLightArray>().ChangeState(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<GameObject> path = allPathNames[Random.Range(0, allPathNames.Count)];
            path[0].GetComponent<SpawnPoint>().SpawnCar(path, allPaths[path]);
        }
    }
}