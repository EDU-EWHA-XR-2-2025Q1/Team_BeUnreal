using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_ACY_Bowl_Controller : MonoBehaviour
{
    public GameObject UI_Controller;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            UI_Controller.GetComponent<TW01_ACY_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}
