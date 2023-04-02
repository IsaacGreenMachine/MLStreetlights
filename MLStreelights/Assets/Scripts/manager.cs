using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public List<GameObject> car_prefabs = new();
    public List<GameObject> spawn_points = new();
    public List<string> directions = new() {"Left", "Forward", "Right"};
    public List<string> lightStates = new() { "Green", "Yellow", "Red", "GreenLeftFull", "GreenLeft", "YellowLeftFull", "YellowLeft" };
    public int carSpeedMin;
    public int carSpeedMax;
    public int yellowDelayTime;
    
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
        if (Input.GetKeyDown(KeyCode.Space))
            spawn_points[0].GetComponent<SpawnPoint>().SpawnCar();
    }
}
