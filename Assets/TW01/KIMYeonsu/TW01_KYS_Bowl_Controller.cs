using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Step 09: ���� ������Ʈ�� [Bowl] �ȿ� ���� Put ������ �ø���

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