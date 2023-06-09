using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    Transform bottom;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
        bottom = transform.GetChild(0);
    }

    public GameObject GetSpawnCar(Vector3 pos)
    {
        return Instantiate(managerScript.car_prefabs[Random.Range(0, managerScript.car_prefabs.Count - 1)], pos, transform.rotation);
    }

    public void SpawnCar()
    {
        GameObject spawn_point = managerScript.spawn_points[Random.Range(0, managerScript.spawn_points.Count)];

        Collider[] hitColliders = Physics.OverlapBox(spawn_point.transform.position, spawn_point.transform.localScale / 1.5f);
        foreach(Collider c in hitColliders)
            if (c.gameObject.CompareTag("car")) return;
        GameObject car;
        int coinFlip = Random.Range(0, 2);
        if (coinFlip == 0)
        {
            car = GetSpawnCar(transform.GetChild(0).transform.position);
        }
            
        else
            car = GetSpawnCar(transform.GetChild(1).transform.position);
        Car carScript = car.GetComponent<Car>();
        carScript.speed = Random.Range(managerScript.carSpeedMin, managerScript.carSpeedMax);
        carScript.direction = managerScript.directions[Random.Range(0, 3)];
        carScript.lane = coinFlip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnCar();
    }

}
