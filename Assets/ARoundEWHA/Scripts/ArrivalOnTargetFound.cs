using UnityEngine;
using Vuforia;
using TMPro;

public class ArrivalOnTargetFound : MonoBehaviour
{
    [Header("숨길 Panel")]
    [SerializeField] private GameObject panel;

    [Header("도착 메시지 텍스트")]
    [SerializeField] private TextMeshProUGUI arrivalMessage;

    private bool hasArrived = false;

    void Start()
    {
        // 시작할 때 비활성화
        if (panel != null) panel.SetActive(false);
        if (arrivalMessage != null) arrivalMessage.gameObject.SetActive(false);

        var observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (hasArrived) return;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            hasArrived = true;

            if (panel != null) panel.SetActive(true);
            if (arrivalMessage != null)
            {
                arrivalMessage.text = "아산공학관 도착 성공!";
                arrivalMessage.gameObject.SetActive(true);
            }
        }
    }
}
