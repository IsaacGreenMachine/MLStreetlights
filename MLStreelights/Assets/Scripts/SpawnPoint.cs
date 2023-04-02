using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
    }

    public GameObject GetSpawnCar()
    {
        GameObject car = Instantiate(managerScript.car_prefabs[Random.Range(0, managerScript.car_prefabs.Count - 1)]);
        car.AddComponent<Car>();
        car.AddComponent<BoxCollider>();
        car.transform.Rotate(0, -90, 0);
        return car;
    }

    public void SpawnCar()
    {
        List<GameObject> spawn_points = managerScript.spawn_points;
        GameObject spawn_point = spawn_points[Random.Range(0, spawn_points.Count)];

        // Doesn't work //
        // Checks if car is already in spawn point
        Collider[] hitColliders = Physics.OverlapBox(spawn_point.transform.position, spawn_point.transform.localScale / 2);
        Debug.Log(hitColliders.Length);
        if (hitColliders.Length > 0) return;

        GetSpawnCar().transform.position = spawn_point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnCar();
    }
}
