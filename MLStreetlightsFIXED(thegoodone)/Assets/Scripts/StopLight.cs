using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    public string lightState;
    public GameObject greenCoverL;
    public GameObject yellowCoverL;
    public GameObject redCoverL;
    public GameObject greenCoverR;
    public GameObject yellowCoverR;
    public GameObject redCoverR;

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
                greenCoverL.SetActive(true);
                yellowCoverL.SetActive(true);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(false);
                yellowCoverR.SetActive(true);
                redCoverR.SetActive(true);
            }
            else if (state == "Yellow")
            {
                greenCoverL.SetActive(true);
                yellowCoverL.SetActive(true);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(true);
                yellowCoverR.SetActive(false);
                redCoverR.SetActive(true);
            }
            else if (state == "Red")
            {
                greenCoverL.SetActive(true);
                yellowCoverL.SetActive(true);
                redCoverL.SetActive(false);
                greenCoverR.SetActive(true);
                yellowCoverR.SetActive(true);
                redCoverR.SetActive(false);
            }
            else if (state == "GreenLeft")
            {
                greenCoverL.SetActive(false);
                yellowCoverL.SetActive(true);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(true);
                yellowCoverR.SetActive(true);
                redCoverR.SetActive(false);
            }
            else if (state == "GreenLeftFull")
            {
                greenCoverL.SetActive(false);
                yellowCoverL.SetActive(true);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(false);
                yellowCoverR.SetActive(true);
                redCoverR.SetActive(true);
            }
            else if (state == "YellowLeft")
            {
                greenCoverL.SetActive(true);
                yellowCoverL.SetActive(false);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(true);
                yellowCoverR.SetActive(true);
                redCoverR.SetActive(false);
            }
            else if (state == "YellowLeftFull")
            {
                greenCoverL.SetActive(true);
                yellowCoverL.SetActive(false);
                redCoverL.SetActive(true);
                greenCoverR.SetActive(true);
                yellowCoverR.SetActive(false);
                redCoverR.SetActive(true);
            }
            lightState = state;
        }
    }
}