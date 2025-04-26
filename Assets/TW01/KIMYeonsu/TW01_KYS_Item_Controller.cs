using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Step01: [Item_Original] 클릭하기
//Step03: 마우스로 복제한 Item 을 클릭하면 클릭한 횟수는 변수에 할당하고 클릭한 클론은 Destroy 하기


public class TW01_KYS_Item_Controller : MonoBehaviour
{
    public GameObject PickController; // Step03 (TW01_KYS_Pick_Controller.cs 를 갖고 있는 게임 오브젝트용 변수)
    private void OnMouseDown()
    {
        PrintInfo(); // Step01
        PickController.GetComponent<TW01_KYS_Pick_Controller>().Add_Click(gameObject);
        // Step03
    }
    // Step01: 게임 오브젝트의 이름 출력
    void PrintInfo()
    {
        print($"{gameObject.name}을/를 클릭했습니다.");
    }
}