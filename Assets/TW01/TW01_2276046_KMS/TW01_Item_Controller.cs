using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_Item_Controller : MonoBehaviour
{
    public GameObject PickController;   
    private void OnMouseDown()
    {
        PrintInfo();                  
        PickController.GetComponent<TW01_Pick_Controller>().Add_Click(gameObject); // Step03
    }
    void PrintInfo()
    {
        print($"{gameObject.name}을/를 클릭했습니다.");
    }
}
