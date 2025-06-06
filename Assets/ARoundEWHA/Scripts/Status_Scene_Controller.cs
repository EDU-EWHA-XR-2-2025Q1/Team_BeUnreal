using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status_Scene_Controller : MonoBehaviour
{
    public TextMeshProUGUI infoText;        // "후윳길 > 이화여대 정문" 경로가 들어있는 텍스트
    public TextMeshProUGUI messageText;     // 실제로 메시지를 띄울 텍스트 (이동중... 또는 도착!)

    void Start()
    {
        string route = SceneTracker.RouteText;  // 이전 씬에서 가져온 텍스트
        string suffix = SceneTracker.PreviousSceneName.EndsWith("_Item") ? " 도착!" : " 이동중...";

        infoText.text = route;
        messageText.text = route + suffix;
    }
}
