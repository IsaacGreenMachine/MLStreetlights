using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnCar()
    {
        GameObject car = Instantiate(managerScript.car_prefabs[Random.Range(0, managerScript.car_prefabs.Count - 1)]);
        return car;
    }
}
