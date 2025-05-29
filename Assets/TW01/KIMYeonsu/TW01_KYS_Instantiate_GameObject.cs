using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Step02: [Item_Original]�� �����ϱ�

public class TW01_KYS_Instantiate_GameObject : MonoBehaviour
{
    public GameObject Target; // Step02 (������ ����)
    public int cloneCount = 10; // Step02 (������ ����)
    void Start()
    {
        Instantiate_GameObject(); // Step02 (������ ����)
    }
    // Step02: ���� ������Ʈ(������)�� �����ϴ� �Լ�
    void Instantiate_GameObject()
    {
        for (int i = 0; i < cloneCount; i++)
        {
            // ������ Ŭ���� ������ position
            Vector3 randomSphere = Random.insideUnitSphere * 5f;
            randomSphere.y = 0f;
            Vector3 randomPos = randomSphere;
            // ������ Ŭ���� ������ rotation
            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);
            // Ŭ������ ����
            GameObject Clone = Instantiate(Target, randomPos, randomRot);
            // Ŭ�� Ȱ��ȭ
            Clone.SetActive(true);
            // Ŭ���� �̸� ����
            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);
            // Ŭ���� �θ� ����
            Clone.transform.SetParent(transform);
        }
    }
}
