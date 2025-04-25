using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_KYR_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0;
    public GameObject UI;
    bool isInTheArea = false;

    public void Add_Click(GameObject Clone)
    {
        if (isInTheArea)
        {
            clickCounter++;
            Destroy(Clone);
            UI.GetComponent<TW01_KYR_UI_Controller>().Display_PickCounts(clickCounter);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = false;
        }
    }
}
