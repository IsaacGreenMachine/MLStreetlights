using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPaths : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript; 
    public Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
    }

    public GameObject SpawnCar()
    {
        GameObject car = Instantiate(managerScript.car_prefabs[Random.Range(0, managerScript.car_prefabs.Count - 1)]);
        return car;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
