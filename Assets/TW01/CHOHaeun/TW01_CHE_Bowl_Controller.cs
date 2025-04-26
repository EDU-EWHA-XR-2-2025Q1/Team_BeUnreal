using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_CHE_Bowl_Controller : MonoBehaviour
{
    public GameObject UI_Controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            UI_Controller.GetComponent<TW01_CHE_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}
