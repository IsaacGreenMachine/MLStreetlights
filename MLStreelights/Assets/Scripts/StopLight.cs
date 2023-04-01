using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    public string lightState;
    public GameObject greenCover;
    public GameObject yellowCover;
    public GameObject redCover;

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

    public void ChangeState(string state)
    {
        if (!managerScript.lightStates.Contains(state))
            Debug.Log(string.Format("invalid direction '{0}'", state));
        else
        {
            if (state == "Green")
            {
                greenCover.SetActive(false);
                yellowCover.SetActive(true);
                redCover.SetActive(true);
            }
            else if (state == "Yellow")
            {
                greenCover.SetActive(true);
                yellowCover.SetActive(false);
                redCover.SetActive(true);
            }
            else if (state == "Red")
            {
                greenCover.SetActive(true);
                yellowCover.SetActive(true);
                redCover.SetActive(false);
            }
            else if (state == "GreenLeft")
            {

            }
            else if (state == "Left")
            {

            }
            else if (state == "FlashingYellowLeft")
            {

            }
            else if (state == "GreenRight")
            {

            }
            lightState = state;
        }
    }
}
