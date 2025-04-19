using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW01_Instantiate_GameObject : MonoBehaviour
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
            Vector3 randomSphere = Random.insideUnitSphere * 5f;
            randomSphere.y = 0f;
            Vector3 randomPos = randomSphere;
            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);
            GameObject Clone = Instantiate(Target, randomPos, randomRot);
            Clone.SetActive(true);
            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);
            Clone.transform.SetParent(transform);
        }
    }
}
