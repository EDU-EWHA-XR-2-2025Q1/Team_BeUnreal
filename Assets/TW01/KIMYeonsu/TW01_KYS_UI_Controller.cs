using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Step 04: Item �� Ŭ���� Ƚ���� UI �� ǥ���ϱ�
//Step 05: ���� ������Ʈ�� ������
//Step 07: ���� ������Ʈ�� ������ Pick ���� ���̱�
//Step 08: Pick ������ ����� ���� ���� �� �ֵ��� �ϱ�

public class TW01_KYS_UI_Controller : MonoBehaviour
{
    public TMP_Text PickCounts; // Step04
    public TMP_Text PutCounts; // Step05

    // step04
    public void Display_PickCounts(int count)
    {
        PickCounts.text = count.ToString();
    }

    // step05
    public void Display_PutCounts()
    {
        int lastPutCount = int.Parse(PutCounts.text);
        int currentPutCount = lastPutCount + 1;
        PutCounts.text = currentPutCount.ToString();
    }

    // step07
    public void Decrease_PickCounts()
    {
        int lastPickCount = int.Parse(PickCounts.text);
        int currentPickCount = lastPickCount - 1;
        PickCounts.text = currentPickCount.ToString();
    }

    // step08
    public int GetPickCounts()
    {
        int pickCounts = int.Parse(PickCounts.text);
        return pickCounts;

    }
}

