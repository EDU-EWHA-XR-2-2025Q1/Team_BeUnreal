﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_MIH_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0;   // 클릭한 클론의 수
    public GameObject UI;   // Step04 (UI 관련 스크립트를 갖고 있는 게임 오브젝트)
    bool isInTheArea = false;

    // clickCounter의 값을 1씩 증가시키는 함수
    public void Add_Click(GameObject Clone)
    {
        if (isInTheArea)
        {
            clickCounter++;
            print($"{clickCounter} 개의 클론을 클릭했습니다.");
            Destroy(Clone);

            // Step04 (UI에 내용을 표시하는 스크립트 호출)
            UI.GetComponent<TW01_MIH_UI_Controller>().Display_PickCounts(clickCounter);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = false;
        }
    }
}
