using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_KYR_Heart_Controller : MonoBehaviour {

    public GameObject PickController;
    private void OnMouseDown()
    {
        PickController.GetComponent<TW01_KYR_Pick_Controller>().Add_Click(gameObject);
    }
}
