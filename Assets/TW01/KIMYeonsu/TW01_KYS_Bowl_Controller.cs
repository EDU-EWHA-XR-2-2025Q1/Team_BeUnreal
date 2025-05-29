using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Step 09: 던진 오브젝트가 [Bowl] 안에 들어가면 Put 점수를 올리기

public class TW01_KYS_Bowl_Controller : MonoBehaviour
{
    public GameObject UI_Controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            UI_Controller.GetComponent<TW01_KYS_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}