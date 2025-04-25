using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_KYR_Heart_Initializer : MonoBehaviour
{

    public GameObject Target;
    public int cloneCount = 10;

    void Start()
    {
        Instantiate_GameObject();
    }
    void Instantiate_GameObject()
    {
        for (int i = 0; i < cloneCount; i++)
        {
            // 복제한 클론의 랜덤한 position 

            Vector3 randomSphere = Random.insideUnitSphere * 5f;

            randomSphere.y = 0f;

            Vector3 randomPos = randomSphere;



            // 복제한 클론의 랜덤한 rotation 

            float randomAngle = Random.value * 360f;

            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);



            // 클론으로 복제 

            GameObject Clone = Instantiate(Target, randomPos, randomRot);



            // 클론 활성화 

            Clone.SetActive(true);



            // 클론의 이름 설정 

            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);



            // 클론의 부모 설정 

            Clone.transform.SetParent(transform);
        }
    }
}
