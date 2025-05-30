using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status_Scene_Controller : MonoBehaviour
{
    public TextMeshProUGUI infoText;        // "������ > ��ȭ���� ����" ��ΰ� ����ִ� �ؽ�Ʈ
    public TextMeshProUGUI messageText;     // ������ �޽����� ��� �ؽ�Ʈ (�̵���... �Ǵ� ����!)

    void Start()
    {
        string route = SceneTracker.RouteText;  // ���� ������ ������ �ؽ�Ʈ
        string suffix = SceneTracker.PreviousSceneName.EndsWith("_Item") ? " ����!" : " �̵���...";

        infoText.text = route;
        messageText.text = route + suffix;
    }
}
