using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int speed;
    public string direction;
    public GameObject manager;
    public manager managerScript;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
        speed = Random.Range(managerScript.carSpeedMin, managerScript.carSpeedMax);
        direction = managerScript.directions[Random.Range(0, managerScript.directions.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.right * Time.deltaTime * 3);
    }
}
