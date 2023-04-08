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
    public List<GameObject> paths1 = new();
    public List<GameObject> paths2 = new();
    public List<GameObject> paths3 = new();
    public List<GameObject> paths4 = new();
    public List<GameObject> paths5 = new();
    public List<GameObject> paths6 = new();
    public List<GameObject> paths7 = new();
    public List<GameObject> paths8 = new();
    public List<GameObject> paths9 = new();
    public List<GameObject> paths10 = new();
    public List<GameObject> paths11 = new();
    public List<GameObject> paths12 = new();
    public List<GameObject> paths13 = new();
    public List<GameObject> paths16 = new();
    public List<GameObject> paths14 = new();
    public List<GameObject> paths15 = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject car in Resources.LoadAll("Prefabs"))
            car_prefabs.Add(car);
        foreach (Transform transformChild in GameObject.Find("SpawnPoints").transform)
            spawn_points.Add(transformChild.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}