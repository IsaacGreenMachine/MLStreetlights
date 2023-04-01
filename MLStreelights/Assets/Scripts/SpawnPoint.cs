using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject manager;
    public List<GameObject> car_prefabs;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        car_prefabs = manager.GetComponent<manager>().car_prefabs;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnCar()
    {
        GameObject car = Instantiate(car_prefabs[Random.Range(0, car_prefabs.Count - 1)]);
        return car;
    }
}
