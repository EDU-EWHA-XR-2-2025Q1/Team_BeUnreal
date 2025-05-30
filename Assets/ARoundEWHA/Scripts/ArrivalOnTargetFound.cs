using UnityEngine;
using Vuforia;
using TMPro;

public class ArrivalOnTargetFound : MonoBehaviour
{
    [Header("���� Panel")]
    [SerializeField] private GameObject panel;

    [Header("���� �޽��� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI arrivalMessage;

    private bool hasArrived = false;

    void Start()
    {
        // ������ �� ��Ȱ��ȭ
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
                arrivalMessage.text = "�ƻ���а� ���� ����!";
                arrivalMessage.gameObject.SetActive(true);
            }
        }
    }
}
