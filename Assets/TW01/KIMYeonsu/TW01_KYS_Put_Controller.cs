using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Step 05: ���� ������Ʈ�� ������
//Step 06: [Put_Area_Cube] ���� �������� ���� �� �ֵ��� ����
//Step 07: ���� ������Ʈ�� ������ Pick ���� ���̱�
//Step 08: Pick ������ ����� ���� ���� �� �ֵ��� �ϱ�


public class TW01_KYS_Put_Controller : MonoBehaviour
{
    public GameObject TargetObjectToThrow;
    public Transform PlayerCamera;
    bool isInTheArea = false; // step06: ���� �� �ִ� ������ �ִ����� ����
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
        // ������ Ŭ���� ������ rotation
        float randomAngleX = Random.value * 360f;
        float randomAngleY = Random.value * 360f;
        float randomAngleZ = Random.value * 360f;
        Quaternion randomRot = Quaternion.Euler(randomAngleX, randomAngleY, randomAngleZ);

        // �����ϱ�
        GameObject Clone = Instantiate(TargetObjectToThrow, Pos, randomRot);
        // ������ Ŭ�� ����
        Clone.SetActive(true);
        Clone.GetComponent<Collider>().isTrigger = false;
        Clone.GetComponent<Rigidbody>().useGravity = true;
        // ������
        Clone.GetComponent<Rigidbody>().AddForce(PlayerCamera.forward * 400f);
        // �Ҹ��Ű��
        Destroy(Clone, 3);
    }

    //Step 06: [Put_Area_Cube] ���� �������� ���� �� �ֵ��� ����
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
