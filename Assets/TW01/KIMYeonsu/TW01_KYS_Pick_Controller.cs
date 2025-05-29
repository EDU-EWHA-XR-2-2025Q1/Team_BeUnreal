using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Step03: 마우스로 복제한 Item 을 클릭하면 클릭한 횟수는 변수에 할당하고 클릭한 클론은 Destroy 하기
//Step04: Item 을 클릭한 횟수를 UI 에 표시하기


public class TW01_KYS_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0; // 클릭한 클론의 수
    public GameObject UI; // Step04 (UI 관련 스크립트를 갖고 있는 게임 오브젝트)
                          
    // clickCounter 의 값을 1 씩 증가시키는 함수
    public void Add_Click(GameObject Clone)
    {
        clickCounter++;
        print($"{clickCounter} 개의 클론을 클릭했습니다.");
        Destroy(Clone);

        // Step04 (UI 에 내용을 표시하는 스크립트 호출)
        UI.GetComponent<TW01_KYS_UI_Controller>().Display_PickCounts(clickCounter);
    }
}