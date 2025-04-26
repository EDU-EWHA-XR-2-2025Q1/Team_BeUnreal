using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Step03: ���콺�� ������ Item �� Ŭ���ϸ� Ŭ���� Ƚ���� ������ �Ҵ��ϰ� Ŭ���� Ŭ���� Destroy �ϱ�
//Step04: Item �� Ŭ���� Ƚ���� UI �� ǥ���ϱ�


public class TW01_KYS_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0; // Ŭ���� Ŭ���� ��
    public GameObject UI; // Step04 (UI ���� ��ũ��Ʈ�� ���� �ִ� ���� ������Ʈ)
                          
    // clickCounter �� ���� 1 �� ������Ű�� �Լ�
    public void Add_Click(GameObject Clone)
    {
        clickCounter++;
        print($"{clickCounter} ���� Ŭ���� Ŭ���߽��ϴ�.");
        Destroy(Clone);

        // Step04 (UI �� ������ ǥ���ϴ� ��ũ��Ʈ ȣ��)
        UI.GetComponent<TW01_KYS_UI_Controller>().Display_PickCounts(clickCounter);
    }
}
