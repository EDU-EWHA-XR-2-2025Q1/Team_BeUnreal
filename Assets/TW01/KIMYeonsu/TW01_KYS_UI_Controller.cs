using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Step 04: Item 을 클릭한 횟수를 UI 에 표시하기
//Step 05: 게임 오브젝트를 던지기
//Step 07: 게임 오브젝트를 던지면 Pick 점수 줄이기
//Step 08: Pick 점수가 양수일 때만 던질 수 있도록 하기

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

