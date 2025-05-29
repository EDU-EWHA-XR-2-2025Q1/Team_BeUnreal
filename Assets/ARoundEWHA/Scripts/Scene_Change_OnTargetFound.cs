using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class SceneChangerOnTargetFound : MonoBehaviour
{
    public string sceneNameToLoad = "";  

    private ObserverBehaviour observerBehaviour;
    private bool isSceneLoaded = false;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();

        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (!isSceneLoaded &&
            targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            isSceneLoaded = true;
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
