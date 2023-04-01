using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public List<GameObject> car_prefabs = new();
    public List<GameObject> spawn_points = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject car in Resources.LoadAll("Prefabs"))
            car_prefabs.Add(car);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            spawn_points[0].GetComponent<SpawnPoint>().SpawnCar();
    }
}
