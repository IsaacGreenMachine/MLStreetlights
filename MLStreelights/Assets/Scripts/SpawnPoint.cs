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
        car.transform.Rotate(0, 180, 0);
        return car;
    }

    public void SpawnCar()
    {
        GameObject spawn_point = managerScript.spawn_points[Random.Range(0, managerScript.spawn_points.Count)];

        Collider[] hitColliders = Physics.OverlapBox(spawn_point.transform.position, spawn_point.transform.localScale / 1.5f);
        foreach(Collider c in hitColliders)
        {
            Debug.Log(c.tag);
            if (c.gameObject.CompareTag("car")) return;
        }
        int coinFlip = Random.Range(0, 2);
        float offset = spawn_point.transform.localScale.z / 4;
        if (coinFlip == 0)
        {
            GetSpawnCar().transform.position = spawn_point.transform.position + new Vector3(0, 0, coinFlip);
        }
        else
        {
            GetSpawnCar().transform.position = spawn_point.transform.position - new Vector3(0, 0, coinFlip);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnCar();
    }

}
