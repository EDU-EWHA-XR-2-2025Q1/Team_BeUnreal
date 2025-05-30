using System.Collections;
using System.Collections.Generic;
using TMPro; //text mesh pro
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Change : MonoBehaviour
{
    public TextMeshProUGUI routeTextField;  // Text (TMP)_Information ����

    public void OnClick_LoadScene(Object SceneObject)
    {
        Debug.Log(SceneObject.name);

        string currentScene = SceneManager.GetActiveScene().name;
        SceneTracker.PreviousSceneName = currentScene;

        Debug.Log("Saved previous scene: " + currentScene);
        Debug.Log("Loading scene: " + SceneObject.name);

        // �߰�: �ؽ�Ʈ ���� ����
        if (routeTextField != null)
        {
            SceneTracker.RouteText = routeTextField.text;
            Debug.Log("Saved Route Text: " + SceneTracker.RouteText);
        }

        SceneManager.LoadScene(SceneObject.name);
    }

    // Status ������ ���� ������ ���ư���
    public void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(SceneTracker.PreviousSceneName))
        {
            Debug.Log("Returning to: " + SceneTracker.PreviousSceneName);
            SceneManager.LoadScene(SceneTracker.PreviousSceneName);
        }
        else
        {
            Debug.LogWarning("No previous scene recorded.");
        }
    }
}