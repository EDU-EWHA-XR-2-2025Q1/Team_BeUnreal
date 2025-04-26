using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_CHE_Item_Controller : MonoBehaviour
{
    public GameObject Pick_Controller;

    void OnMouseDown()
    {
        print($"{gameObject.name} clicked");
        Pick_Controller.GetComponent<TW01_CHE_Pick_Controller>().Increase_PickCount(gameObject);
    }
}
