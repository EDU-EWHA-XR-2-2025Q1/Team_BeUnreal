using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Step 05: 게임 오브젝트를 던지기
//Step 06: [Put_Area_Cube] 영역 내에서만 던질 수 있도록 수정
//Step 07: 게임 오브젝트를 던지면 Pick 점수 줄이기
//Step 08: Pick 점수가 양수일 때만 던질 수 있도록 하기


public class TW01_KYS_Put_Controller : MonoBehaviour
{
    public GameObject TargetObjectToThrow;
    public Transform PlayerCamera;
    bool isInTheArea = false; // step06: 던질 수 있는 영역에 있는지의 여부
    public GameObject UI;       // step07

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInTheArea)
        {
            //step 08
            int pickCounts = UI.GetComponent<TW01_KYS_UI_Controller>().GetPickCounts();
            if (pickCounts > 0)
            {
                Throw();
                UI.GetComponent<TW01_KYS_UI_Controller>().Decrease_PickCounts(); //step07
            }
            
        }
    }
    void Throw()
    {
        Vector3 Pos = PlayerCamera.position + PlayerCamera.forward;
        // 복제할 클론의 랜덤한 rotation
        float randomAngleX = Random.value * 360f;
        float randomAngleY = Random.value * 360f;
        float randomAngleZ = Random.value * 360f;
        Quaternion randomRot = Quaternion.Euler(randomAngleX, randomAngleY, randomAngleZ);

        // 복제하기
        GameObject Clone = Instantiate(TargetObjectToThrow, Pos, randomRot);
        // 복제한 클론 설정
        Clone.SetActive(true);
        Clone.GetComponent<Collider>().isTrigger = false;
        Clone.GetComponent<Rigidbody>().useGravity = true;
        // 던지기
        Clone.GetComponent<Rigidbody>().AddForce(PlayerCamera.forward * 400f);
        // 소멸시키기
        Destroy(Clone, 3);
    }

    //Step 06: [Put_Area_Cube] 영역 내에서만 던질 수 있도록 수정
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
