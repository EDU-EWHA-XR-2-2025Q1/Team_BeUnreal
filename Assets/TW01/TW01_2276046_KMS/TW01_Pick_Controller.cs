using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0;  
    public GameObject UI;   
    bool isInTheArea = false;              

    public void Add_Click(GameObject Clone)
    {
        if(isInTheArea){
            clickCounter++;
            print($"{clickCounter} 개의 클론을 획득했습니다.");
            Destroy(Clone);
            UI.GetComponent<TW01_UI_Controller>().Display_PickCounts(clickCounter);

        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
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
