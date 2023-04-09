using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class StopLightArray : MonoBehaviour
{
    public GameObject manager;
    public manager managerScript;
    // N E S W
    public List<GameObject> lights = new();

    public bool currentlySwitching;

    public int lightState;
    /*   0 : All Red
     *  *Two Greens and Two Reds*
     *   1 N/S 
     *   2 E/W
     *  *One Green + Left*
     *   3 N 
     *   4 E
     *   5 S
     *   6 W
     *  *Two Lefts and Two Reds*
     *   7 N/S
     *   8 E/W
     */

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("manager");
        managerScript = manager.GetComponent<manager>();
        currentlySwitching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlySwitching)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
                ChangeState(0);
            else if (Input.GetKeyDown(KeyCode.Alpha1))
                ChangeState(1);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                ChangeState(2);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                ChangeState(3);
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                ChangeState(4);
            else if (Input.GetKeyDown(KeyCode.Alpha5))
                ChangeState(5);
            else if (Input.GetKeyDown(KeyCode.Alpha6))
                ChangeState(6);
            else if (Input.GetKeyDown(KeyCode.Alpha7))
                ChangeState(7);
            else if (Input.GetKeyDown(KeyCode.Alpha8))
                ChangeState(8);
        }
    }
    public void ChangeState(int state)
    {
        if (state != lightState)
            StartCoroutine(ChangeStateRoutine(state));
    }

    IEnumerator ChangeStateRoutine(int state)
    {
        currentlySwitching = true;
        // switching to yellow light and waiting
        if (lightState == 0)
            yield return new WaitForSeconds(0);
        else if (lightState == 1)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Yellow");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Yellow");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 2)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Yellow");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Yellow");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 3)
        {
            lights[0].GetComponent<StopLight>().ChangeState("YellowLeftFull");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 4)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("YellowLeftFull");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 5)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("YellowLeftFull");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 6)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("YellowLeftFull");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 7)
        {
            lights[0].GetComponent<StopLight>().ChangeState("YellowLeft");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("YellowLeft");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }
        else if (lightState == 8)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("YellowLeft");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("YellowLeft");
            yield return new WaitForSeconds(managerScript.yellowDelayTime);
        }



        // changing final light color
        if (state == 0)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 1)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Green");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Green");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 2)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Green");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Green");
        }


        else if (state == 3)
        {
            lights[0].GetComponent<StopLight>().ChangeState("GreenLeftFull");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 4)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("GreenLeftFull");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 5)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("GreenLeftFull");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 6)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("GreenLeftFull");
        }
        else if (state == 7)
        {
            lights[0].GetComponent<StopLight>().ChangeState("GreenLeft");
            lights[1].GetComponent<StopLight>().ChangeState("Red");
            lights[2].GetComponent<StopLight>().ChangeState("GreenLeft");
            lights[3].GetComponent<StopLight>().ChangeState("Red");
        }
        else if (state == 8)
        {
            lights[0].GetComponent<StopLight>().ChangeState("Red");
            lights[1].GetComponent<StopLight>().ChangeState("GreenLeft");
            lights[2].GetComponent<StopLight>().ChangeState("Red");
            lights[3].GetComponent<StopLight>().ChangeState("GreenLeft");
        }

        lightState = state;
        currentlySwitching = false;
    }
}