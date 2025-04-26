using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Step01: [Item_Original] Ŭ���ϱ�
//Step03: ���콺�� ������ Item �� Ŭ���ϸ� Ŭ���� Ƚ���� ������ �Ҵ��ϰ� Ŭ���� Ŭ���� Destroy �ϱ�


public class TW01_KYS_Item_Controller : MonoBehaviour
{
    public GameObject PickController; // Step03 (TW01_KYS_Pick_Controller.cs �� ���� �ִ� ���� ������Ʈ�� ����)
    private void OnMouseDown()
    {
        PrintInfo(); // Step01
        PickController.GetComponent<TW01_KYS_Pick_Controller>().Add_Click(gameObject);
        // Step03
    }
    // Step01: ���� ������Ʈ�� �̸� ���
    void PrintInfo()
    {
        print($"{gameObject.name}��/�� Ŭ���߽��ϴ�.");
    }
}