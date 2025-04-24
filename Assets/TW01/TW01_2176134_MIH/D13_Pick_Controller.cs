using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D13_Pick_Controller : MonoBehaviour
{
    int pickCount = 0;
    bool isInTheArea = false;

    public GameObject UI;

    public void Increase_PickCount(GameObject Clone)
    {
        if (isInTheArea)
        {
            pickCount++;
            print($"pick count: {pickCount}");
            Destroy(Clone);
            UI.GetComponent<D13_UI_Controller>().DIsplay_PickCounts(pickCount);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "FPSController")
        {
            isInTheArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "FPSController")
        {
            isInTheArea = false;
        }
    }
}
